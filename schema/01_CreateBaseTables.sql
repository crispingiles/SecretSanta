use SecretSanta

CREATE TABLE dbo.Person
(
	PersonId INT NOT NULL IDENTITY(1,1),
	EmailAddress VARCHAR(256) NOT NULL,

	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED
	(
		PersonId ASC
	),

	CONSTRAINT [UNQ_Person_EmailAddress] UNIQUE NONCLUSTERED
	(
		EmailAddress ASC
	)
)

CREATE TABLE dbo.List
(
	ListId INT NOT NULL IDENTITY(1,1),
	Name VARCHAR(512) NOT NULL,
	Description VARCHAR(MAX) NOT NULL,

	CONSTRAINT [PK_List] PRIMARY KEY CLUSTERED
	(
		ListId ASC
	)
)

CREATE TABLE dbo.ListPerson
(
	ListPersonId INT NOT NULL IDENTITY(1,1),
	ListId INT NOT NULL,
	PersonId INT NOT NULL,

	CONSTRAINT [PK_ListPerson] PRIMARY KEY CLUSTERED
	(
		ListPersonId ASC
	),

	CONSTRAINT [FK_ListPerson_ListId] FOREIGN KEY (ListId) REFERENCES [dbo].[List] (ListId),
	CONSTRAINT [FK_ListPerson_PersonId] FOREIGN KEY (PersonId) REFERENCES [dbo].[Person] (PersonId),
	CONSTRAINT [UNQ_ListPerson_ListId_PersonId] UNIQUE NONCLUSTERED
	(
		ListId ASC,
		PersonId ASC
	)
)