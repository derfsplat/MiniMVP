using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xunit;
using MiniMVP.Contrib;

namespace MiniMVP.Tests
{
    public class Tests
    {
      class SimpleBinding
      {
        public int Value { get; set; }
        public string Display { get; set; }
      }

      [Fact]
      public void ComboBoxExtensions_WithPoco_ReturnsValidVAlue()
      {
        Fixture fixture = new Fixture();
        var objs = fixture.CreateMany<SimpleBinding>().ToList();

        ComboBox cbo = new ComboBox();
        cbo.DisplayMember = "Display";
        cbo.ValueMember = "Value";
        objs.ForEach(obj => cbo.Items.Add(obj));
        cbo.SelectedIndex = 0;

        Assert.Equal(objs[0].Value, cbo.GetSelectedValue<int>());        
      }
    }
}
