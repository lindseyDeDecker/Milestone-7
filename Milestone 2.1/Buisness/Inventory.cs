﻿using static Milestone_2._1.Buisness.Inventory;

namespace Milestone_2._1.Buisness
{
    public class Inventory
    {
        //An array to hold all of the books
        List<Book> books = new List<Book>();

        //List of books that are a part of the search
        List<Book> searchBook= new List<Book>();

        //saving value of the row click
        int selectedRow = -1;
        public class Book
        {
            //Create attributes of the class book
            private string title = "";
            private string author = "";
            private double quantity;
            private double price;
            private double isbn;
            private string genre = "";

            //getters and setters for the varaibles I want for the books
            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            public string Author
            {
                get { return author; }
                set { author = value; }
            }
            public double Quantity
            {
                get { return quantity; }
                set { quantity = value; }
            }
            public double Price
            {
                get { return price; }
                set { price = value; }
            }
            public double Isbn
            {
                get { return isbn; }
                set { isbn = value; }
            }
            public string Genre
            {
                get { return genre; }
                set { genre = value; }
            }
        }
        public List<Book> GetInventory()
        {
            //Pulls text from the inventory file
            using StreamReader sr = new StreamReader("C:\\Users\\kydec\\Desktop\\Lindsey School\\CSR 150\\Activity 2\\Milestone 2.1\\bin\\Debug\\net8.0-windows\\Inventory.txt");
            {
                //loop to run while there is text to read from the file
                while (!sr.EndOfStream)
                {
                    //putting each line into a string
                    string line = sr.ReadLine();
                    //breaking appart the string by |
                    string[] info = line.Split(new char[] { '|' });

                    //creating a new book from each part of the string
                    Book b = new Book();

                    //Creating variables for all items in the stirng.  
                    //converting some to double and int
                    b.Title = info[0];
                    b.Author = info[1];
                    b.Price = double.Parse(info[2]);
                    b.Quantity = double.Parse(info[3]);
                    b.Isbn = double.Parse(info[4]);
                    b.Genre = info[5];

                    //Add the book to the book array
                    books.Add(b);
                }
            }
            return books;
        }
        
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DisplayInventory(DataGridView dataInfo)
        {
            //loop to display all books into the grid
            foreach (Book b in books)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataInfo);

                row.Cells[0].Value = b.Title;
                row.Cells[1].Value = b.Author;
                row.Cells[2].Value = b.Price;
                row.Cells[3].Value = b.Quantity;
                row.Cells[4].Value = b.Isbn;
                row.Cells[5].Value = b.Genre;

                dataInfo.Rows.Add(row);
            }
        }
        //This method will search the books using the text box information. 
        //It will then put any books that hit the search into a new list 
        public List<Book> SearchBooks(List<Book> book, List<Book> searchBook, string search)
        {
            //Clear the search inventory
            searchBook.Clear();

            //Loop through each book
            foreach (Book b in books)
            {
                //This statement checks to see if the search matches the title or the genre
                if(b.Title.ToLower().Contains(search.ToLower()) || b.Genre.ToLower().Contains(search.ToLower()))
                {
                    //Any matches will be added to the searchBook list
                    searchBook.Add(b);
                }
            }
            //Return the new list
            return searchBook;
        }


        public void IncreaseInventory(DataGridView dataInfo, int rowSelected)
        {
            Book selectedBook = books[rowSelected];

            //adding 1 to quantity
            selectedBook.Quantity += 1;

            //putting that new value into the grid
            dataInfo.Rows[rowSelected].Cells[3].Value = selectedBook.Quantity;
        }


        public void DecreaseInventory(DataGridView dataInfo, int rowSelected)
        {
            Book selectedBook = books[rowSelected];

            selectedBook.Quantity -= 1;

            dataInfo.Rows[rowSelected].Cells[3].Value = selectedBook.Quantity;
        }
        //Method to return the new book array after updates have been made
            public List<Book> GetBooks()
            {
             return books;
            }

          }
}
