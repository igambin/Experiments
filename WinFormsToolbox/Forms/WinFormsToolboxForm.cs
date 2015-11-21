using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Toolbox.Core;
using WinFormsToolbox.Interfaces;

namespace WinFormsToolbox.Forms
{
    public partial class WinFormsToolboxForm : Form
    {
        public WinFormsToolboxForm()
        {
            InitializeComponent();

            CategoryChooser.DataSource = Enum.GetValues(typeof(Categories));
            CategoryChooser.SelectedIndex = 0;

            ToolChooser.DisplayMember = "ToolName";

            LoadTools();
        }

        [ImportMany]
#pragma warning disable 649
        private IEnumerable<Lazy<IWinFormsTool, IWinFormsToolData>> _tools;
#pragma warning restore 649

        private class ToolChooserEntry
        {
            public string ToolName { get; }
            public Lazy<IWinFormsTool, IWinFormsToolData> Tool { get; }

            public ToolChooserEntry(Lazy<IWinFormsTool, IWinFormsToolData> tool)
            {
                Tool = tool;
                ToolName = tool.Metadata.ToolName;
            }
        }

        private IList<ToolChooserEntry> _filteredTools;

        private void LoadTools()
        {
            try
            {

                if(_tools == null)
                {
                    var catalog = new AggregateCatalog();
                    catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));

                    var container = new CompositionContainer(catalog);

                    container.ComposeParts(this);

                    UpdateToolChooser();                
                }

            } catch(CompositionException e)
            {
                Debug.WriteLine(e.ToString());
            } catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void UpdateToolChooser()
        {
            Categories c = Categories.All;
            if (CategoryChooser.SelectedIndex >= 0 && _tools != null)
            {
                c = (Categories)CategoryChooser.SelectedItem;
                _filteredTools = _tools.Where(x => x.Metadata.ToolCategory.HasFlag(c)).Select(x => new ToolChooserEntry(x)).ToList();
                ToolChooser.SelectedItem = null;
                ToolChooser.Items.Clear();
                ToolChooser.Items.AddRange(_filteredTools.ToArray());
                if (_filteredTools.Any())              {
                    ToolChooser.SelectedIndex = 0;
                }
            }

        }

        private void CategoryChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateToolChooser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ToolChooser.SelectedIndex >= 0)
            {
                var selectedEntry = ToolChooser.SelectedItem as ToolChooserEntry;

                var tool = selectedEntry.Tool.Value;

                var form = tool.GetModuleForm();
                form.Show(this);
            }
        }

        private void ToolTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ToolChooser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
