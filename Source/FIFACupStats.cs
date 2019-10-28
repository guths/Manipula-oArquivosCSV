using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Codenation.Challenge
{
    public class Player
    {
        public string Name { get; set; }

        public string FullName { get; set; }
        public int? Age { get; set; }
        public string Club { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }
        public double? Salary { get; set; }
        public double? ReleaseClause { get; set; }

        //public Player(string name, int age, string club, DateTime birthDate, string nationality, double salary, double releaseClause)
        //{
        //    this.Name = name;
        //    this.Age = age;
        //    this.Club = club;
        //    this.Nationality = nationality;
        //    this.Salary = salary;
        //    this.ReleaseClause = releaseClause;
        //}

        public Player()
        {
        }
    }

    public class FIFACupStats
    {

        public FIFACupStats()
        {
            listPlayers=File.ReadAllLines("data.csv").Select(a => a.Split(';')).Select(c => new Player()
            {
                Name = c[COLUMN_NAME],
                FullName = c[COLUMN_FULL_NAME],
                Age = Convert.ToInt32(c[COLUMN_AGE]),
                Club = c[COLUMN_CLUB],
                BirthDate = Convert.ToDateTime(c[COLUMN_BIRTHDATE]),
                Nationality = c[COLUMN_NATIONALITY],
                Salary = Convert.ToDouble(c[COLUMN_SALARY]),
                ReleaseClause = Convert.ToDouble(c[COLUMN_RELEASECLAUSE])
            }).ToList();
        }
        const int COLUMN_NAME = 1;
        const int COLUMN_FULL_NAME = 2;
        const int COLUMN_AGE = 6;
        const int COLUMN_CLUB = 3;
        const int COLUMN_BIRTHDATE = 8;
        const int COLUMN_NATIONALITY = 14;
        const int COLUMN_SALARY = 17;
        const int COLUMN_RELEASECLAUSE = 18;

        public string CSVFilePath { get; set; } = "data.csv";

        public Encoding CSVEncoding { get; set; } = Encoding.UTF8;

        public static List<Player> listPlayers; File.ReadAllLines("data.csv").Select(a => a.Split(';')).Select(c => new Player()
                    {
                        Name = c[COLUMN_NAME],
                        FullName=c[COLUMN_FULL_NAME],
                        Age = Convert.ToInt32(c[COLUMN_AGE]),
                        Club = c[COLUMN_CLUB],
                        BirthDate = Convert.ToDateTime(c[COLUMN_BIRTHDATE]),
                        Nationality = c[COLUMN_NATIONALITY],
                        Salary = Convert.ToDouble(c[COLUMN_SALARY]),
                        ReleaseClause = Convert.ToDouble(c[COLUMN_RELEASECLAUSE])
                    }).ToList();

        

        public int NationalityDistinctCount()
        {
            var NationalityList = listPlayers.Select<Player, string>(x => x.Nationality).Distinct().Count();
            return NationalityList;
        }

        public int ClubDistinctCount()
        {
            var ClubNames = listPlayers.Select<Player, string>(x => x.Club).Distinct().Count();
            return ClubNames;
        }

        public List<string> First20Players()
        {
            var ListName = listPlayers.Select<Player, string>(x => x.FullName).Take(20).OrderByDescending(x=>x).ToList();
            return ListName;
        }

        public List<string> Top10PlayersByReleaseClause()
        {
            var TopReleaseClauseList = listPlayers.OrderByDescending(x => x.ReleaseClause).Select<Player, string>(x => x.FullName).Take(10).ToList();
            return TopReleaseClauseList;
        }

        public List<string> Top10PlayersByAge()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, int> AgeCountMap()
        {
            throw new NotImplementedException();
        }
    }
}
