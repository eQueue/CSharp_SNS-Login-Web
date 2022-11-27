USE WORKFLOWDB
GO

IF  (OBJECT_ID('PrivateSchema.TblUserData') IS NOT NULL)
DROP TABLE	PrivateSchema.TblUserData
GO

CREATE TABLE PrivateSchema.TblUserData (
	_idx			BIGINT					IDENTITY(1,1)	NOT NULL
	,_IdData		BIGINT									NOT NULL
	,_emailData		NVARCHAR(100)			DEFAULT('')		NOT NULL
	,_nickNameData	NVARCHAR(100)			DEFAULT('')		NOT NULL
	,_profileData	NVARCHAR(100)			DEFAULT('')		NOT NULL
	,_snsNameData	NVARCHAR(100)			DEFAULT('')		NOT NULL
)

ALTER TABLE PrivateSchema.TblUserData ADD CONSTRAINT PkTblUserData PRIMARY KEY(
	_idx
)