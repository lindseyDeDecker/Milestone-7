using static Milestone_2._1.Buisness.Inventory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.ConstrainedExecution;
using static Milestone_2._1.inventoryForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using Milestone_2._1.Buisness;

/*
 * Lindsey DeDecker
 * CST - 150
 * Milestone 2
 * July 13, 2024
 * Gaddis, T. (2019). Starting out with Visual C# (5th ed.). Pearson. ISBN-13: 9780135183519
 * 
 */

namespace Milestone_2._1
{
    public partial class inventoryForm : Form
    {
        //declaring a type inventory that can be used to store an instance of inventory class.
        private Buisness.Inventory inventory;

        List<Book> Book = new List<Book>();

        List<Book> searchBooks = new List<Book>();

        public int rowSelected = -1;
        public int scolumnSelected = -1;
        public inventoryForm()
        {
            InitializeComponent();
            //Initializing the instance of inventory
            inventory = new Buisness.Inventory();
            //Make the label for inventory not visible
            dataInfo.Visible = false;
        }

        private void lblInventory_Click(object sender, EventArgs e)
        {
            //The label for the inventory will be displayed
            dataInfo.Visible = true;

            //Call method that gets the inventory and put it into the array
            List<Buisness.Inventory.Book> inventoryBooks = inventory.GetInventory();

            //Display the inventory in the grid
            inventory.DisplayInventory(dataInfo);
        }
        private void addInventory_Click(object sender, EventArgs e)
        {
            if (rowSelected >= 0 && rowSelected < dataInfo.Rows.Count)
            {
                //Calling method to icrease the invetory of the selected cell
                inventory.IncreaseInventory(dataInfo, rowSelected);
            }
            else
            {
                MessageBox.Show("Please select a valid cell to increase inventory.");
            }
        }

        private void dataInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                rowSelected = e.RowIndex;
            }
        }

        //This button will replace the file with the updated books. 
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //Calling getbooks to get the updated array of books
            List<Book> books = inventory.GetBooks();
            //Use the stream writer to send the new array of books back into the document so that it is updated.
            using StreamWriter sw = new StreamWriter("C:\\Users\\kydec\\Desktop\\Lindsey School\\CSR 150\\Activity 2\\Milestone 2.1\\bin\\Debug\\net8.0-windows\\Inventory.txt");
            {
                foreach (var b in books)
                {
                    //Make sure the books are being broken up with | so that it can be read correctly the next time.
                    string line = $"{b.Title}|{b.Author}|{b.Price}|{b.Quantity}|{b.Isbn}|{b.Genre}";
                    sw.WriteLine(line);
                }
            }
            //Notidy user that the updates have been saved to the file
            string confirmation = "Your changes have been saved!";
            MessageBox.Show(confirmation);
        }

        private void btnDecreaseInventory_Click(object sender, EventArgs e)
        {
            if (rowSelected >= 0 && rowSelected < dataInfo.Rows.Count)
            {
                inventory.DecreaseInventory(dataInfo, rowSelected);
            }
            else
            {
                MessageBox.Show("Please select a valid cell to decrease inventory.");
            }
        }



        private void btnNewBook_Click(object sender, EventArgs e)
        {
            //Validate that all strings are strings
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Title, Author and Genre require a string and can not be empty.");
                return;
            }

            //validate that price, qty and isbn are all doubles
            if (!double.TryParse(txtPrice.Text, out double price) ||
                !double.TryParse(txtQty.Text, out double quantity) ||
                !double.TryParse(txtIsbn.Text, out double isbn))
            {
                MessageBox.Show("Price, qty and ISBN must contain numbers and can not be empty.");
                return;
            }

            Buisness.Inventory.Book newBook = new Buisness.Inventory.Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Price = double.Parse(txtPrice.Text),
                Quantity = double.Parse(txtQty.Text),
                Isbn = double.Parse(txtIsbn.Text),
                Genre = txtGenre.Text,
            };

            //Add the new book to inventory
            inventory.AddBook(newBook);

            //Add the new book to the DataGridView
            AddBookToDataGridView(newBook);

            //Clear the text fields
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtIsbn.Clear();
            txtGenre.Clear();
        }

        private void AddBookToDataGridView(Buisness.Inventory.Book book)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataInfo);

            row.Cells[0].Value = book.Title;
            row.Cells[1].Value = book.Author;
            row.Cells[2].Value = book.Price;
            row.Cells[3].Value = book.Quantity;
            row.Cells[4].Value = book.Isbn;
            row.Cells[5].Value = book.Genre;

            dataInfo.Rows.Add(row);
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            string message = "Please click on the book you would like to delete and click the delete button on your keyboard!";
            MessageBox.Show(message);
        }

        //This event has the user deleting a book completely from the inventory
        private void dataInfo_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            inventory.DecreaseInventory(dataInfo, rowSelected);
        }

        //This event will trigger the search form to populate with the results
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //First we need to read the textbox to know what we are searching for
            string search = txtSearch.Text;
            //Send it to the buisness layer


            searchBooks = inventory.SearchBooks(Book, searchBooks, search);

            FrmSearch frmSearch = new FrmSearch(searchBooks);

            frmSearch.ShowDialog();
         
        }
    }
}
