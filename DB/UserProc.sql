USE WORKFLOWDB
GO

IF  (OBJECT_ID('PublicSchema.uspGetUserData') IS NOT NULL)
DROP PROCEDURE PublicSchema.uspGetUserData
GO

----유저 조회 
CREATE PROCEDURE PublicSchema.uspGetUserData
(
	@p_idx					BIGINT				
	,@p_IdData				BIGINT						
	,@p_nickNameData		NVARCHAR(100)
	,@p_snsNameData			NVARCHAR(100)			               
)
AS
BEGIN
    --프로시저 로직 작성


	IF(ISNULL(@p_IdData,0)=0) --전체조회
		BEGIN
			SELECT _idx	,_IdData, _emailData, _nickNameData, _profileData, _snsNameData
				FROM WORKFLOWDB.PrivateSchema.TblUserData

		END
	ELSE
		BEGIN
			SELECT _idx	,_IdData, _emailData, _nickNameData, _profileData, _snsNameData
				FROM WORKFLOWDB.PrivateSchema.TblUserData
				WHERE _idx=@p_idx OR (_IdData=@p_IdData AND _snsNameData=@p_snsNameData)

		END


END
GO


--유저 등록
IF  (OBJECT_ID('PublicSchema.uspInsertUserData') IS NOT NULL)
DROP PROCEDURE PublicSchema.uspInsertUserData
GO
 
CREATE PROCEDURE PublicSchema.uspInsertUserData
(
	 @p_IdData		BIGINT
     ,@p_nickNameData	NVARCHAR(100)
	 ,@p_snsNameData	NVARCHAR(100)
	 ,@resultCode		INT			OUTPUT       
)
AS
BEGIN
    --프로시저 로직 작성
	SET @resultCode = -2

	BEGIN TRY
        BEGIN TRAN -- 트랜젝션 시작
			INSERT INTO PrivateSchema.TblUserData(_IdData,_nickNameData,_snsNameData) values(@p_IdData,@p_nickNameData,@p_snsNameData)
        COMMIT TRAN -- 커밋
		SET @resultCode = 0

		SELECT _idx	,_IdData, _emailData, _nickNameData, _profileData, _snsNameData
				FROM WORKFLOWDB.PrivateSchema.TblUserData
				WHERE _IdData=@p_IdData

				
    END TRY
    BEGIN CATCH
		ROLLBACK TRAN -- 롤백
		SET @resultCode = -1

    END CATCH


END
GO