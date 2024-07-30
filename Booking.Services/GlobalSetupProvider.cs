using Booking.DataAccess.Models;
using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.GlobalSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class GlobalSetupProvider : BasicService
    {
            private BookingContext context;

            public GlobalSetupProvider(BookingContext booking)
            {
                this.context = booking;
            }

            public IndexGlobalSetupDTO AllGlobalSetup(int page)
            {
                var dto = new IndexGlobalSetupDTO();
                using (var dbContext = new BookingContext())
                {
                    var query = from globalSetup in dbContext.MstSetupMenus
                                where !globalSetup.DeletedDate.HasValue
                                orderby globalSetup.ParameterCode
                                select new RowGlobalSetupDTO
                                {
                                    ParamterCode = globalSetup.ParameterCode,
                                    ParamterName = globalSetup.ParameterName,
                                    ParamterDesc = globalSetup.ParameterDescription,
                                    ParamterValue = globalSetup.ParameterValue
                                };
                    var totalData = GetTotalPage(query.Count());
                    query = query.Skip(GetSkip(page)).Take(10);
                    dto.RowGlobalSetup = query.ToList();
                    dto.TotalPages = totalData;
                }
                return dto;
            }

            public void InsertGlobalSetup(CreatedGlobalSetupDTO model)
            {
                var newData = new MstSetupMenu();
                newData.ParameterCode = model.ParamterCode;
                newData.ParameterName = model.ParamterName;
                newData.ParameterDescription = model.ParamterDesc;
                newData.ParameterValue = model.ParamterValue;
                newData.CreatedDate = DateTime.UtcNow;
                newData.CreatedBy = 1;
                context.MstSetupMenus.Add(newData);
                context.SaveChanges();
            }

            public MstSetupMenu GetGlobalSetup(string parameterCode)
            {
                return context.MstSetupMenus.SingleOrDefault(globalSetup => globalSetup.ParameterCode == parameterCode);
            }

            public void UpdateGlobalSetup(CreatedGlobalSetupDTO model)
            {
                var getData = GetGlobalSetup(model.ParamterCode);
                getData.ParameterCode = model.ParamterCode;
                getData.ParameterName = model.ParamterName;
                getData.ParameterDescription = model.ParamterDesc;
                getData.ParameterValue = model.ParamterValue;
                getData.UpdatedDate = DateTime.UtcNow;
                getData.UpdatedBy = 1;
                context.SaveChanges();
            }

            public void DeleteGlobalSetup(string parameterCode)
            {
                var getData = GetGlobalSetup(parameterCode);
                getData.DeletedDate = DateTime.UtcNow;
                getData.DeletedBy = 1;
                context.SaveChanges();
            }
    }
}
