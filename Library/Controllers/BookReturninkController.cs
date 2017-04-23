using Library.Models.TableElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers
{
    class BookReturninkController
    {
        public void ReturnBook(int idbook)
        {
            Book book = DAO.GetBookTable().GetElement(idbook);
            book.status = DAO.GetBookStatusTable().GetElement(1);
            DAO.GetBookTable().UpdateElementInDB(book);
        }
    }
}
