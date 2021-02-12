using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class MockData
    {
        public void InsertData()
        {
            var DA = new DataAccess();


            string britten = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES('Britt-Inger Stenberg', 1951, 'Kiruna', null, null, null, null
);";
            string olleS = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES('Olle Stenberg', 1951, 'Kiruna', null, null, null, null
);";

            string majbritt = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Maj-Britt Eriksson', 1936, 'Kiruna', null, null, 2017, 'Kiruna'
);";

            string olleE = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Olle Eriksson', 1936, 'Kiruna', null, null, 2012, 'Kiruna'
);";

            string mats = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Mats Eriksson', 1959, 'Kiruna', 3, 4, null, null
);

";
            string anette = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Anette Isaksen', 1966, 'Kiruna', 1, 2, null, null
);";
            string hanna = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Hanna Gjertström', 1986, 'Kiruna', 1, 2, null, null
);";
            string mattias = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Mattias Gjertström', 1981, 'Kiruna', null, null, null, null
);
";
            string lasse = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Lars Eriksson', 1963, 'Kiruna', 3, 4, null, null
);";
            string tommy = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Tommy Eriksson', 1957, 'Kiruna', 3, 4, null, null
);";
            string pia = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Pia Sällström', 1965, 'Kiruna', 3, 4, null, null
);";
            string annhelene = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Ann-Helene Alm', 1963, 'Luleå', null, null, null, null
);
";
            string ricky = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Ricky Eriksson', 1984, 'Luleå', 12, 5, null, null
);";
            string nicklas = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Nicklas Eriksson', 1994, 'Kiruna', 6, 5, null, null
);";
            string hans = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Hans Isaksen', 1971, 'Tromsö', null, null, null, null
);";
            string tuva = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Tuva-Lisa Isaksen', 2010, 'Kiruna', 6, 15, null, null
);";
            string theo = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Theo Gjertström', 2009, 'Kiruna', 7, 8, null, null
);";
            string tindra = @"INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Tindra Gjertström', 2012, 'Kiruna', 7, 8, null, null
);";

            string[] allFamilyMembers = { britten, olleS, majbritt, olleE, mats, anette, hanna, mattias, lasse, tommy, pia, annhelene, ricky, nicklas, hans, tuva, theo, tindra };
            DA.SQLQuery(allFamilyMembers);

        }

        public void DeleteData()
        {
            string delete = "DELETE FROM dbo.People;";
            var DA = new DataAccess();
            DA.SQLQuery(delete);
        }
    }
}
