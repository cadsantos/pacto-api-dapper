USE [DBO_PACTO]
GO

/****** Object:  StoredProcedure [dbo].[sp_ObterTiposFinalizacoes]    Script Date: 17/05/2024 15:07:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_ObterTiposFinalizacoes]	
AS

BEGIN	
	SET NOCOUNT ON;

SELECT 
    [COD_TIPO_FINALIZACAO] AS Id,
    [TXT_NOME] AS Nome,
    [TXT_DESCRICAO] AS Descricao,
    [DAT_INC] AS DataInclusao,
    [IND_ATIVO] AS Ativo
FROM 
    [DBO_PACTO].[dbo].[TB_TIPO_FINALIZACAO] WITH (NOLOCK)

END
GO

