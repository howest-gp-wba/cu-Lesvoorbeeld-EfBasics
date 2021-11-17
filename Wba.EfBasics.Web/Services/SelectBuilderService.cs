using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Web.Data;

namespace Wba.EfBasics.Web.Services
{
    public class SelectBuilderService
    {
        public async Task<List<SelectListItem>> GetSelectList(SchoolDbContext schoolDbContext)
        {
            return await schoolDbContext
                .Teachers
                .Select(t => new SelectListItem
                {
                    Text = $"{t.Firstname} {t.Lastname}",
                    Value = t.Id.ToString()
                }).ToListAsync();
        }
    }
}
