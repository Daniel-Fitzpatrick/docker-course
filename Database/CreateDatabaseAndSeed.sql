use master
go

CREATE DATABASE podcasts

GO

USE podcasts
go

CREATE TABLE podcasts
(
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Title NVARCHAR(1000) NOT NULL
)

go

INSERT INTO podcasts
(
    Title
)
VALUES
('In the News')
,('Inside Politics')
,('This Paranormal Life')
,('In Review')
,('Retry')
,('Gamescast')
,('Prepare to Try')
,('Inside Business')
,('The Athletic FC')