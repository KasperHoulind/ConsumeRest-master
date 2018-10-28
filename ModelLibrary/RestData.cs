using System;

namespace ModelLibrary
{
    public class RestData
    {
        private int _userid;
        private int _id;
        private string _title;
        private bool _completed;

        public RestData()
        {
        }


        public RestData(int userid, int id, string title, bool completed)
        {
            this._userid = userid;
            this._id = id;
            this._title = title;
            this._completed = completed;

        }

        public int Userid
        {
            get => _userid;
            set => _userid = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;

        }

        public bool Completed
        {
            get => _completed;
            set => _completed = value;

            
        }

        public override string ToString()
        {
            return $"{nameof(Userid)}: {Userid}, {nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(Completed)}: {Completed}";
        }


    }


    
}
