USE [DBO_PACTO]
GO

/****** Object:  StoredProcedure [dbo].[sp_ObterTiposAssinaturas]    Script Date: 17/05/2024 15:07:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_ObterTiposAssinaturas]	
AS

BEGIN	
	SET NOCOUNT ON;

SELECT 
    [COD_TIPO_ASSINATURA] AS Id,
    [TXT_NOME] AS Nome,
    [DAT_INC] AS DataInclusao,
    [IND_ATIVO] AS Ativo
FROM 
    [DBO_PACTO].[dbo].[TB_TIPO_ASSINATURA] WITH (NOLOCK)
END

GO

