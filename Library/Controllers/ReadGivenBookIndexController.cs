using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.TableElements;
namespace Library.Controllers
{
    class ReadGivenBookIndexController
    {
        public void GiveBook(int idbook, int idclient)
        {
            Book book = DAO.GetBookTable().GetElement(idbook);
            Profile profile = DAO.GetProfileTable().GetElement(idclient);
            book.recipient = profile;
            book.issueDate = DateTime.Now;
            book.status = DAO.GetBookStatusTable().GetElement(2);
            DAO.GetBookTable().UpdateElementInDB(book);
        }
    }
}
