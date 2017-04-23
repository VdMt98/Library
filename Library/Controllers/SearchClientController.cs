using Library.Models;
using Library.Models.TableElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers
{
    class SearchClientController
    {
        public ObservableCollection<BookRow> Startup()
        {
            ObservableCollection<BookRow> bookRowlist = new ObservableCollection<BookRow>(DAO.GetBookTable().GetRowsOfBooksInuseByRecipient(Main.Instance.client.id));
            return bookRowlist;
        }

        public ObservableCollection<Book> getSearchedList(string quarry, bool isForName)
        {
            ObservableCollection<Book> list;

            if (isForName == true)
                list = new ObservableCollection<Book>(DAO.GetBookTable().GetBooksByName(quarry));
            else
                list = new ObservableCollection<Book>(DAO.GetBookTable().GetBooksByAuthor(quarry));

            return list;
        }
    }
}
