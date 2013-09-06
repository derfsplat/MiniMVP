using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniMVP.Contrib;

namespace MiniMVP.Contrib
{
    public static class ComboBoxExtensions
    {
        public static bool IsSelectedValueNull(this ComboBox cbo)
        {
            return cbo.SelectedValue == null || cbo.SelectedValue == DBNull.Value;
        }

        public static T GetDataRowValue<T>(this ComboBox cbo, string columnName)
        {
            if (cbo.SelectedItem is DataRow)
            {
                var row = cbo.SelectedItem as DataRow;
                if (row.Table.Columns.Contains(columnName))
                    return (T)row[columnName];
            }
            return default(T);
        }

        public static T GetSelectedValue<T>(this ComboBox cbo)
        {
            if (!cbo.IsSelectedValueNull())
            {
                if (cbo.SelectedValue.GetType() == typeof(T))
                    return (T)cbo.SelectedValue;
            }
            else if(cbo.SelectedItem != null && !cbo.ValueMember.IsNullOrWhiteSpace())
            {
                var pi = cbo.SelectedItem.GetType().GetProperty(cbo.ValueMember, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (pi != null && pi.PropertyType == typeof(T))
                    return (T)pi.GetValue(cbo.SelectedItem, null);
            }
            return default(T);
        }
    }
}
