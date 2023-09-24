namespace testdome
{

    public class Song
    {
        /*
         * A playlist is considered a repeating playlist if any of the songs contain a reference to a precious song in the playlist.
         * Otherwise, the playlist will end with the last sone which points to null.
         * 
         * Implement a function IsInRepeatingPlaylist that, efficiently with respect to time used, 
         * returns true if a playlist is repeating or false if it is not
         */
        private string name;
        public Song NextSong { get; set; }

        public Song()
        {
            //this.name = name;
        }
        public Song(string name)
        {
            this.name = name;
        }

        public bool IsInRepeatingPlaylist()
        {
            Song slow = this;
            Song fast = this.NextSong;

            while (slow != fast)
            {
                if (fast == null || fast.NextSong == null) return false;

                slow = slow.NextSong;
                fast = fast.NextSong.NextSong;
            }

            return true;
        }

        public void Print()
        {
            //Song first = new Song("Hello");
            //Song second = new Song("Eye of the tiger");

            int count = 100;

            List<Song> list = new List<Song>();


            for (int i = 0; i < count; i++)
            {
                list.Add(new Song($"Song {i}"));
            }

            for (int i = 0; i < count - 1; i++)
            {
                list[i].NextSong = list[i + 1];
            }
            list[count - 1].NextSong = list[0];

            //first.NextSong = second;
            //second.NextSong = first;


            Console.WriteLine(list[0].IsInRepeatingPlaylist());
        }
    }
}
