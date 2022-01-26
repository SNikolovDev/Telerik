using System;

namespace BoardR
{
    public class BoardItem
    {
        //title - describes what this item is about;
        //dueDate - when it should be done;
        //status - describes the state of this item - being worked on, being completed, etc..;

        public string title;
        public DateTime dueDate;
        public Status status;

        public BoardItem(string title, DateTime dueDate)
        {
            if (title == null)
            {
                throw new NullReferenceException();
            }

            else if (title.Length < 5 || title.Length > 30 || title == string.Empty)
            {
                throw new Exception("Title length should be between 5 and 30 characters!");
            }

            this.title = title; // non-empty, at least several characters, [5-30];

            if (dueDate <= DateTime.Now)
            {
                throw new Exception("Time and date must be in the future!");
            }
            this.dueDate = dueDate; // must be in the future;

            this.status = Status.Open;// must be Open on initialisaton;
        }

        //public string Title
        //{
        //    get => this.title;
        //    set
        //    {
        //        if (value == null)
        //        {
        //            throw new NullReferenceException();
        //        }

        //        else if (value.Length < 5 || value.Length > 30 || value == string.Empty)
        //        {
        //            throw new Exception("Title length should be between 5 and 30 characters!");
        //        }

        //        this.title = value;
        //    }
        //}
        //public DateTime DueDate
        //{
        //    get => this.dueDate;
        //    set
        //    {
        //        if (value <= DateTime.Now)
        //        {
        //            throw new Exception("Time and date must be in the future!");
        //        }

        //        this.dueDate = value;
        //    }
        //}
        //public Status Status { get => this.status; set => this.status = value; }
        public void RevertStatus()
        {
            if (this.status == Status.Open)
            {
                return;
            }

            this.status--;
        }
        public void AdvanceStatus()
        {
            if (this.status == Status.Verified)
            {
                return;
            }

            status++;
        }
        public string ViewInfo()
        {
            return $"'{this.title}', [{this.status}|{dueDate:dd-MM-yyyy}]";
        }
    }
}
