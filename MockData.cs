using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FamilyTree
{
    internal class MockData
    {
        internal List<Person> GetData(List<Person> people)
        {
            var DA = new DataAccess();
            bool dbExists = CheckDatabaseExists(Utility.Cnn("FamilyTreeDB"), "FamilyTree_NicklasEriksson");
            string createDB = "CREATE DATABASE FamilyTree_NicklasEriksson;";

            if (dbExists)
            {
                DA.RemakeTable();
                people = DA.AddMockData();
                DA.AlterMockData();
            }
            else
            {
                SqlConnection connect = new SqlConnection(Utility.Cnn("FamilyTreeDB"));
                SqlCommand cmd = new SqlCommand();
                try
                {
                    connect.Open();
                    cmd.Connection = connect;
                    cmd.CommandText = createDB;
                    cmd.ExecuteNonQuery();
                    AddStoredProcedures();
                }
                catch
                {
                    connect.Close();
                }
                finally
                {
                    connect.Close();
                    DA.RemakeTable();
                    people = DA.AddMockData();
                    DA.AlterMockData();
                }
            }
            return people;
        }

        /// <summary>
        /// On startup > creates the stored procedures needed for the program to run.
        /// </summary>
        private void AddStoredProcedures()
        {
            SetUpStoredProcedures SP = new SetUpStoredProcedures();
            SP.InsertMockData();
            SP.AlterMockData();
            SP.CreateTablePeople();
            SP.Delete();
            SP.EmptyTable();
            SP.FindSiblings();
            SP.Insert();
            SP.SearchLIKE();
            SP.UpdatePerson();
            SP.GetAll();
        }

        internal static bool CheckDatabaseExists(string connectionString, string databaseName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection))
                {
                    connection.Open();
                    return (command.ExecuteScalar() != DBNull.Value);
                }
            }
        }
    }

    internal class SetUpStoredProcedures
    {
        SqlConnection connect = new SqlConnection(Utility.Cnn("FamilyTreeDB"));
        SqlCommand cmd = new SqlCommand();

        internal void InsertMockData()
        {
            #region Stored procedure insertMD
            string insertMD = @"CREATE PROCEDURE [dbo].[People_InsertMockData]
AS
INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES('Britt-Inger Stenberg', 1951, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES('Olle Stenberg', 1951, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Maj-Britt Eriksson', 1936, 'Kiruna', null, null, 2017, 'Kiruna'
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Olle Eriksson', 1936, 'Kiruna', null, null, 2012, 'Kiruna'
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Mats Eriksson', 1959, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Anette Isaksen', 1966, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Hanna Gjertström', 1986, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Mattias Gjertström', 1981, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Lars Eriksson', 1963, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Tommy Eriksson', 1957, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Pia Sällström', 1965, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Ann-Helene Alm', 1963, 'Luleå', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Ricky Eriksson', 1984, 'Luleå', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Nicklas Eriksson', 1994, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Hans Isaksen', 1971, 'Tromsö', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Tuva-Lisa Isaksen', 2010, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Theo Gjertström', 2009, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Tindra Gjertström', 2012, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Pär Eriksson', 1986, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Daniel Eriksson', 1983, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Hanna Eriksson', 1985, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Sanna Eriksson', 1996, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Eliza Eriksson', 1981, 'Kiruna', null, null, 2021, 'Kiruna'
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Monica Strebjer', 1966, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'William Strebjer', 1999, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Jonathan Harnesk', 1993, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Anna-Lisa Öström', 1931, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Stian Isaksen', 1990, 'Tromsö', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Stina Eriksson', 1959, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Ola Sällström', 1955, 'Kiruna', null, null, null, null
);

INSERT INTO  dbo.People 
(fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath)
VALUES(	'Eva Öström', 1953, 'Kiruna', null, null, 2020, 'Kiruna'
);
";
            #endregion Stored procedure
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = insertMD;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connect.Close();
            }
            finally
            {
                connect.Close();               
            }
        }

        internal void AlterMockData() 
        {
            #region alterMD
            string alterMD = @"CREATE PROCEDURE [dbo].[People_AlterMockData]
AS

UPDATE dbo.People
SET People.motherId = 1, People.fatherId = 2 --Britt-Inger & Olle S
WHERE People.id = 6;-- and People.id = 7 --Anette & Hanna

UPDATE dbo.People
SET People.motherId = 1, People.fatherId = 2 --Britt-Inger & Olle S
WHERE People.id = 7; --Hanna

UPDATE dbo.People
SET motherId = 3, fatherId = 4 --Maj-Britt & Olle E
WHERE id = 5 --Mats

UPDATE dbo.People
SET motherId = 3, fatherId = 4 --Maj-Britt & Olle E
WHERE id = 9 --Lars

UPDATE dbo.People
SET motherId = 3, fatherId = 4 --Maj-Britt & Olle E
WHERE id = 10 --Tommy

UPDATE dbo.People
SET motherId = 3, fatherId = 4 --Maj-Britt & Olle E
WHERE id = 11 --Pia

UPDATE dbo.People
SET motherId = 6--Anette
WHERE id = 14 --Nicklas

UPDATE dbo.People
SET motherId = 6, fatherId = 15 --Anette & Hans
WHERE id = 16 --Tuva

UPDATE dbo.People
SET fatherId = 5 --Mats
WHERE id = 14 --Nicklas

UPDATE dbo.People
SET motherId = 12, fatherId = 5 --Mats & Ann-Helene
WHERE id = 13 --Ricky

UPDATE dbo.People
SET motherId = 7, fatherId = 8 --Hanna & Mattias
WHERE id = 17--Theo

UPDATE dbo.People
SET motherId = 7, fatherId = 8 --Hanna & Mattia
WHERE id = 18 -- Tindra
------------------------------------
UPDATE dbo.People
SET motherId = 29, fatherId = 9 --Stina E & Lars E
WHERE id = 19 -- Pär

UPDATE dbo.People
SET motherId = 29, fatherId = 9 --Stina E & Lars E
WHERE id = 20 -- Daniel

UPDATE dbo.People
SET motherId = 11, fatherId = 30 --Pia S & Ola S
WHERE id = 21 -- Hanna

UPDATE dbo.People
SET motherId = 11, fatherId = 30 --Pia S & Ola S
WHERE id = 22 -- Sanna

UPDATE dbo.People
SET fatherId = 10 --Tommy E 
WHERE id = 23 -- Eliza E

UPDATE dbo.People
SET motherId = 31 --Eva Ö 
WHERE id = 24 -- Monica

UPDATE dbo.People
SET motherId = 24 --Monica
WHERE id = 25 -- William

UPDATE dbo.People
SET motherId = 24 --Monica
WHERE id = 26 -- Jonathan H

UPDATE dbo.People
SET fatherId = 15 --Hans
WHERE id = 28 -- Stian

UPDATE dbo.People
SET motherId = 27 --Anna-Lisa
WHERE id = 31 -- Eva

UPDATE dbo.People
SET motherId = 27 --Anna-Lisa
WHERE id = 1 -- Britt-Inger
";
            #endregion alterMD

            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = alterMD;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connect.Close();
            }
            finally
            {
                connect.Close();              
            }
        }

        internal void CreateTablePeople() 
        {
            #region Stored procedure createTablePeople
            string createTablePeople = @"CREATE PROCEDURE [dbo].[People_CreateTablePeople]
AS
BEGIN
	CREATE TABLE [dbo].[People](
		[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
		[fullName] [varchar](80) NOT NULL,
		[yearOfBirth] [int] NOT NULL,
		[placeOfBirth] [varchar](80) NULL,
		[motherId] [int] NULL,
		[fatherId] [int] NULL,
		[yearOfDeath] [int] NULL,
		[placeOfDeath] [varchar](20) NULL,
		)
--		ALTER TABLE [dbo].[People]  WITH CHECK ADD FOREIGN KEY([fatherId])
--REFERENCES [dbo].[People] ([id])

--ALTER TABLE [dbo].[People]  WITH CHECK ADD FOREIGN KEY([motherId])
--REFERENCES [dbo].[People] ([id])

END";
            #endregion Stored procedure createTablePeople
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = createTablePeople;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connect.Close();
            }
            finally
            {
                connect.Close();
            }
        }

        internal void Delete() 
        {
            #region Stored procedure createTablePeople
            string delete = @"CREATE PROCEDURE [dbo].[People_Delete]
@fullName VARCHAR(40)
AS
BEGIN
DELETE FROM People
WHERE fullName = @fullname
END";
            #endregion Stored procedure createTablePeople
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText =  delete = @"ALTER PROCEDURE [dbo].[People_Delete]
@fullName VARCHAR(40)
AS
BEGIN
DELETE FROM People
WHERE fullName = @fullname
END";
                ;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connect.Close();
            }
            finally
            {
                connect.Close();
            }
        }

        internal void EmptyTable() 
        {
            #region Stored procedure createTablePeople
            string emptyTable = @"CREATE PROCEDURE [dbo].[People_EmptyTable]
AS
BEGIN
DELETE  FROM dbo.People
END
";
            #endregion Stored procedure createTablePeople
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = emptyTable;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connect.Close();
            }
            finally
            {
                connect.Close();
            }
        }

        internal void FindSiblings() 
        {
            #region Stored procedure createTablePeople
            string findSiblings = @"CREATE PROCEDURE [dbo].[People_FindSiblings]
@fullName NVARCHAR(40)
AS
BEGIN
	SELECT DISTINCT id, fullName, yearOfBirth, placeOfBirth, People.motherId,  People.fatherId, yearOfDeath, placeOfDeath 
	FROM People	
	INNER JOIN (
		SELECT  motherId, fatherId
		FROM dbo.People		
		--GROUP BY motherId, fatherId
		--HAVING COUNT (*) > 1
		WHERE fullName = @fullName
	) sq ON (sq.fatherId = People.fatherId
	OR sq.motherId = People.motherID)-- OR (sq.motherId = People.motherId) OR (sq.fatherId = People.fatherId)
	
	
END";
            #endregion Stored procedure createTablePeople
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = findSiblings;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connect.Close();
            }
            finally
            {
                connect.Close();
            }
        }

        internal void Insert() 
        {
            #region Stored procedure createTablePeople
            string insert = @"CREATE PROCEDURE [dbo].[People_Insert]
	--@id int,
	@fullName nvarchar(40),
	@yearOfBirth int = NULL,
	@placeOfBirth nvarchar(40) = NULL,
	@motherId int = NULL,
	@fatherId int = NULL,
	@yearOfDeath int = NULL,
	@placeOfDeath nvarchar(40) = NULL
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.People
	(
	 --id,
	 fullName,
	 yearOfBirth,
	 placeOfBirth,
	 motherId,
	 fatherId,
	 yearOfDeath,
	 placeOfDeath
	)
	VALUES
	(
		--@id,
		@fullName,
		@yearOfBirth,
		@placeOfBirth,
		@motherId,
		@fatherId,
		@yearOfDeath,
		@placeOfDeath
	)	
END";
            #endregion Stored procedure createTablePeople
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = insert;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connect.Close();
            }
            finally
            {
                connect.Close();
            }
        }

        internal void SearchLIKE() 
        {
            #region Stored procedure createTablePeople
            string searchLike = @"CREATE PROCEDURE [dbo].[People_SearchLIKE]
@SearchInput NVARCHAR(40)
AS
BEGIN
SELECT * FROM People
WHERE 
	fullName LIKE '%' + @SearchInput + '%' OR
	yearOfBirth LIKE '%' + @SearchInput + '%' OR 
	placeOfBirth LIKE '%' + @SearchInput + '%' OR
	yearOfDeath LIKE '%' + @SearchInput + '%' OR
	placeOfDeath LIKE '%' + @SearchInput + '%'
END";
            #endregion Stored procedure createTablePeople
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = searchLike;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connect.Close();
            }
            finally
            {
                connect.Close();
            }
        }

        internal void UpdatePerson() 
        {
            #region Stored procedure createTablePeople
            string updatePerson = @"CREATE PROCEDURE [dbo].[People_UpdatePerson]
@id INT,
@fullName NVARCHAR(40),
@yearOfBirth INT,
@placeOfBirth NVARCHAR(20),
@motherId INT,
@fatherId INT,
@yearOfDeath INT,
@placeOfDeath NVARCHAR(20)
AS
BEGIN
UPDATE dbo.People
SET fullName = @fullName, 
	yearOfBirth = @yearOfBirth, 
	placeOfBirth = @placeOfBirth, 
	motherId= @motherId, 
	fatherId= @fatherId, 
	yearOfDeath = @yearOfDeath, 
	placeOfDeath = @placeOfDeath
WHERE id = @id
END";
            #endregion Stored procedure createTablePeople
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = updatePerson;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connect.Close();
            }
            finally
            {
                connect.Close();
            }
        }

        internal void GetAll() 
        {
            #region Stored procedure createTablePeople
            string getAll = @"CREATE PROCEDURE [dbo].[spPeople_GetAll]
AS
BEGIN
set nocount on;

	SELECT id, fullName, yearOfBirth, placeOfBirth, motherId, fatherId, yearOfDeath, placeOfDeath
	FROM dbo.People;
END";
            #endregion Stored procedure createTablePeople
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = getAll;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connect.Close();
            }
            finally
            {
                connect.Close();
            }
        }
    }
}