USE [DBO_PACTO]
GO

/****** Object:  StoredProcedure [dbo].[sp_ObterTiposAlteracoes]    Script Date: 17/05/2024 15:07:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_ObterTiposAlteracoes]	
AS

BEGIN	
	SET NOCOUNT ON;

SELECT 
    [COD_TIPO_ALTERACAO] AS Id,
    [TXT_NOME] AS Nome,
    [TXT_DESCRICAO] AS Descricao,
    [TIP_RESPONSAVEL] AS Responsavel
FROM 
    [DBO_PACTO].[dbo].[TB_TIPO_ALTERACAO]
WITH(NOLOCK);

END

GO

