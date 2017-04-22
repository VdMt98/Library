using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Controllers.TableElements;

namespace Library.Controllers.Tables
{
    public abstract class BaseTable<T> where T : BaseTableElement
    {

        protected List<T> elements;

        protected BaseTable() {
            elements = new List<T>();
        }

        public T GetElement(int id) {

            foreach (T e in elements)
            {
                if (e.id == id)
                    return e;
            }
            try
            {
                T newElement = LoadElementFromDB(id);
                elements.Add(newElement);
                return newElement;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                // TODO: handle exception
            }
            throw new Exception("Can't load element");
        }

        protected abstract string getSql_SelectById(int id);

        protected abstract T LoadElementFromDB(int id);

    }
}
