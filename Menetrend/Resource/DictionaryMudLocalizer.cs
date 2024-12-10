using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace EPicrq.Resource
{
    internal class DictionaryMudLocalizer : MudLocalizer
    {
        private Dictionary<string, string> _localization;

        public DictionaryMudLocalizer()
        {
            _localization = new()
            {
                {"MudDataGrid.AddFilter", "Szűrés"},
                {"MudDataGrid.Apply", "Alkalmaz"},
                {"MudDataGrid.Cancel", "Mégesm"},
                {"MudDataGrid.Clear", "Töröl"},
                {"MudDataGrid.CollapseAllGroups", "Mind összecsuk"},
                {"MudDataGrid.Column", "Oszlop"},
                {"MudDataGrid.Columns", "Oszlopok"},
                {"MudDataGrid.contains", "tartalamazza"},
                {"MudDataGrid.ends with", "végződik"},
                {"MudDataGrid.equals", "egyenlő"},
                {"MudDataGrid.ExpandAllGroups", "Minden csoportot kinyit"},
                {"MudDataGrid.False", "hamis"},
                {"MudDataGrid.Filter", "Szűrő"},
                {"MudDataGrid.FilterValue", "Szűrő érték"},
                {"MudDataGrid.Group", "Csoportosít"},
                {"MudDataGrid.Hide", "Rejt"},
                {"MudDataGrid.HideAll", "Mindent rejt"},
                {"MudDataGrid.is", "van"},
                {"MudDataGrid.is after", "utána"},
                {"MudDataGrid.is before", "elötte"},
                {"MudDataGrid.is empty", "üres"},
                {"MudDataGrid.is not", "nem"},
                {"MudDataGrid.is not empty", "nem üres"},
                {"MudDataGrid.is on or after", "be vagy utána"},
                {"MudDataGrid.is on or before", "ki vagy elötte"},
                {"MudDataGrid.MoveDown", "Mozgatás le"},
                {"MudDataGrid.MoveUp", "Mozgatás fel"},
                {"MudDataGrid.not contains", "nem tartalmazza"},
                {"MudDataGrid.not equals", "nem egyenlő"},
                {"MudDataGrid.Operator", "Operátor"},
                {"MudDataGrid.RefreshData", "Adatok frissítése"},
                {"MudDataGrid.Save", "Mentés"},
                {"MudDataGrid.ShowAll", "Mutasd mind"},
                {"MudDataGrid.Sort", "Rendez"},
                {"MudDataGrid.starts with", "kezdődik"},
                {"MudDataGrid.True", "igaz"},
                {"MudDataGrid.Ungroup", "Csoport bontás"},
                {"MudDataGrid.Unsort", "Rendezés megszüntetése"},
                {"MudDataGrid.Value", "Érték"}
            };
        }

        public override LocalizedString this[string key]
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentUICulture.Parent.TwoLetterISOLanguageName;
                if (currentCulture.Equals("hu", StringComparison.InvariantCultureIgnoreCase)
                    && _localization.TryGetValue(key, out var res))
                {
                    return new(key, res);
                }
                else
                {
                    return new(key, key, true);
                }
            }
        }
    }
}
