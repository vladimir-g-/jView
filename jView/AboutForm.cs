using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jView
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            VersionValueLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();


            Assembly currentAssem = typeof(AboutForm).Assembly;

            object[] companyAttribs = currentAssem.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true);
            if (companyAttribs.Length > 0)
            {
                AuthorValueLabel.Text = ((AssemblyCompanyAttribute)companyAttribs[0]).Company;
            }

            object[] producAttribs = currentAssem.GetCustomAttributes(typeof(AssemblyProductAttribute), true);
            if (producAttribs.Length > 0)
            {
                this.Text = ((AssemblyProductAttribute)producAttribs[0]).Product;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
