USE [crudmvc]
GO

/****** Object:  StoredProcedure [dbo].[SP_USUARIOS]    Script Date: 11/06/2018 13:21:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		CARLOS LIMA
-- Create date: 10/06/18
-- Description:	CRUD - TB_USUARIOS
-- =============================================
CREATE PROCEDURE [dbo].[SP_USUARIOS]
	@OPT NVARCHAR(50) = NULL,
	@ID INT = NULL,
	@NOME NVARCHAR(150) = NULL,
	@EMAIL NVARCHAR(150) = NULL,
	@ATIVO INT = NULL
AS
BEGIN
	-- CREATE
	IF @OPT = 'CriarUsuario' BEGIN
		INSERT INTO TB_USUARIOS VALUES(@NOME, @EMAIL, @ATIVO, GETDATE(), GETDATE());
	END

	-- READ
	IF @OPT = 'ObterTodosUsuarios' BEGIN
		SELECT * FROM TB_USUARIOS;
	END

	IF @OPT = 'ObterUsuarioPorId' BEGIN
		SELECT * FROM TB_USUARIOS WHERE Id = @ID;
	END

	-- UPDATE
	IF @OPT = 'EditarUsuario' BEGIN
		UPDATE TB_USUARIOS SET Nome = @NOME, Email = @EMAIL, Ativo = @ATIVO, DataAtualizacao = GETDATE()
		WHERE Id = @ID;
	END

	-- DELETE
	IF @OPT = 'ExcluirUsuario' BEGIN
		DELETE FROM TB_USUARIOS WHERE Id = @ID;
	END
END
GO

