USE WORKFLOWDB
GO

IF  (OBJECT_ID('PublicSchema.uspGetUserData') IS NOT NULL)
DROP PROCEDURE PublicSchema.uspGetUserData
GO

----���� ��ȸ 
CREATE PROCEDURE PublicSchema.uspGetUserData
(
	@p_idx					BIGINT				
	,@p_IdData				BIGINT						
	,@p_nickNameData		NVARCHAR(100)
	,@p_snsNameData			NVARCHAR(100)			               
)
AS
BEGIN
    --���ν��� ���� �ۼ�


	IF(ISNULL(@p_IdData,0)=0) --��ü��ȸ
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


--���� ���
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
    --���ν��� ���� �ۼ�
	SET @resultCode = -2

	BEGIN TRY
        BEGIN TRAN -- Ʈ������ ����
			INSERT INTO PrivateSchema.TblUserData(_IdData,_nickNameData,_snsNameData) values(@p_IdData,@p_nickNameData,@p_snsNameData)
        COMMIT TRAN -- Ŀ��
		SET @resultCode = 0

		SELECT _idx	,_IdData, _emailData, _nickNameData, _profileData, _snsNameData
				FROM WORKFLOWDB.PrivateSchema.TblUserData
				WHERE _IdData=@p_IdData

				
    END TRY
    BEGIN CATCH
		ROLLBACK TRAN -- �ѹ�
		SET @resultCode = -1

    END CATCH


END
GO