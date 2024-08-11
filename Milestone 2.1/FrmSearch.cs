using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Milestone_2._1.Buisness;



namespace Milestone_2._1
{
    public partial class FrmSearch : Form
    {
        //List of book
        List<Inventory.Book> mySearch;

        public FrmSearch(List<Inventory.Book> search)
        {
            InitializeComponent();

            this.mySearch = search;
        }
        private void FrmSearch_Load(object sender, EventArgs e)
        {
            dgvSearch.DataSource = this.mySearch;

        }
        //This button will close the secondary form when the user is done with the search
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
