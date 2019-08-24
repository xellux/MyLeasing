﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MyLeasing.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboLessees()
        {
            var list = _dataContext.Lessees.Select(l => new SelectListItem
            {
                Text = l.User.FullNameWithDocument,
                Value = $"{l.Id}" //Interpolación. Eficiente. Se envía el Id convertido a un string
            })
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a lessee ...)",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboPropertyTypes()
        {
            var list = _dataContext.PropertyTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}" //Interpolación. Eficiente. Se envía el Id convertido a un string
            })
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a property type ...)",
                Value = "0"
            });
            return list;
        }
    }
}
