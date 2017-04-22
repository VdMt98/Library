using Library.Models;
using Library.Models.TableElements;
using Library.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers
{
    class ReaderMainWindowController
    {   
        public createTable()
        {
            List<Book> bookTablelist = DAO.GetBookTable().GetBooksInuseByRecipientId(LoginController.worker.id);

        }
    }
}
