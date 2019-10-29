using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    abstract class Document
    {
        //All documents have ordernumber, supplier and total amount of money.
        //Currency is not set for total so it is assumed that currency stays the same in order and in invoice and user inputs total from those documents
        private string _orderNumber;
        private string _supplier;
        private double _total;

        //Document ID made to check that program works. There are different lists for orders and invoices in main program for now and therefore list index could also work as ID.
        static int _amountOfDocuments = 1;
        private int _id;

        public Document(string orderNumber, string supplier, double total)
        {
            _orderNumber = orderNumber;
            _supplier = supplier;
            _total = total;
            _id = _amountOfDocuments;
            _amountOfDocuments++;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetOrderNumber()
        {
            return _orderNumber;
        }

        public string GetSupplier()
        {
            return _supplier;
        }

        public double GetTotal()
        {
            return _total;
        }
    }
}
