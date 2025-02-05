using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract11_2_Shengals
{
    public partial class Form1 : Form
    {
        private Library library = new Library();

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            ComboBoxSort.SelectedIndex = -1;
        }

        private void InitializeDataGridView()
        {
            dataGridViewBooks.AutoGenerateColumns = true;
            dataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void RefreshGrid(List<Book> books)
        {
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = books;
        }

        private void ClearFields()
        {
            Txttitle.Clear();
            txtAuthor.Clear();
            TxtYear.Clear();
        }

        private void BtnAdd_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(TxtYear.Text, out int year))
            {
                library.AddBook(new Book
                {
                    Title = Txttitle.Text,
                    Author = txtAuthor.Text,
                    Year = year
                });
                RefreshGrid(library.GetAllBooks());
                ClearFields();
            }
        }

        private void BtnRemove_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow?.DataBoundItem is Book selectedBook)
            {
                library.RemoveBook(selectedBook);
                RefreshGrid(library.GetAllBooks());
            }
        }

        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            if (comboBoxSearchType.SelectedIndex == 0)
            {
                RefreshGrid(library.FindByAuthor(TxtSearch.Text));
            }
            else if (int.TryParse(TxtSearch.Text, out int year))
            {
                RefreshGrid(library.FindByYear(year));
            }
        }

        private void ComboBoxSort_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (ComboBoxSort.SelectedIndex)
            {
                case 0: 
                    library.SortByTitle(); 
                    break;
                case 1: 
                    library.SortByAuthor(); 
                    break;
                case 2:
                    library.SortByYear(); 
                    break;
            }
            RefreshGrid(library.GetAllBooks());
        }
    }

}
