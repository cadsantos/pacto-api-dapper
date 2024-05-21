USE [DBO_PACTO]
GO

/****** Object:  StoredProcedure [dbo].[sp_spObterDocumentosAguardandoFinalizacaoManualPorIdUsuario]    Script Date: 17/05/2024 16:11:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_spObterDocumentosAguardandoFinalizacaoManualPorIdUsuario]
(
	@IdUsuario int
)	
AS

BEGIN	
	SET NOCOUNT ON;

;WITH total_assinaturas AS	
(
	SELECT
		documento_assinante.COD_DOCUMENTO
	FROM
		DBO_PACTO..TB_DOCUMENTO_ASSINANTE documento_assinante WITH (NOLOCK)	
	WHERE
		documento_assinante.COD_STATUS_ASSINATURA = 1
),
	total_assinaturas_realizadas AS	
(
	SELECT
		documento_assinante.COD_DOCUMENTO
	FROM
		DBO_PACTO..TB_DOCUMENTO_ASSINANTE documento_assinante WITH (NOLOCK)	
	WHERE
		documento_assinante.COD_STATUS_ASSINATURA = 1 AND
		documento_assinante.DAT_ASSINATURA_ELETRONICA IS NOT NULL
)

SELECT
	documento.COD_DOCUMENTO AS Id,
	documento.KEY_DOCUMENTO AS [Key],
	documento.TXT_NOME AS Titulo,
	documento.TXT_DESCRICAO AS Descricao,
	(
		SELECT 
			COUNT(assinaturas.COD_DOCUMENTO) 
		FROM 
			total_assinaturas_realizadas assinaturas  WITH (NOLOCK)
		WHERE 
			assinaturas.COD_DOCUMENTO = documento.COD_DOCUMENTO
	) AS TotalAssinaturasRealizadas,
	(
		SELECT 
			COUNT(assinaturas.COD_DOCUMENTO) 
		FROM 
			total_assinaturas assinaturas  WITH (NOLOCK)
		WHERE 
			assinaturas.COD_DOCUMENTO = documento.COD_DOCUMENTO
	) AS TotalAssinaturas,
	status_assinatura.TXT_NOME AS Situacao,
	documento.DAT_INC As DataCadastro,
	documento.DAT_PRAZO_ASSINATURA AS PrazoFinalizacao
FROM
	DBO_PACTO..TB_DOCUMENTO AS documento  WITH (NOLOCK)
INNER JOIN
	DBO_PACTO..TB_DOCUMENTO_ASSINANTE AS documento_assinante  WITH (NOLOCK) ON documento_assinante.COD_DOCUMENTO = documento.COD_DOCUMENTO
INNER JOIN
	DBO_PACTO..TB_STATUS_ASSINATURA AS status_assinatura  WITH (NOLOCK) ON status_assinatura.COD_STATUS_ASSINATURA = documento.COD_STATUS_DOCUMENTO
WHERE
	documento.COD_USUARIO = @IDUsuario AND
	documento.COD_STATUS_DOCUMENTO = 2 	AND
	documento.COD_TIPO_FINALIZACAO = 2 AND
	documento_assinante.COD_DOCUMENTO_ASSINANTE IN 
	(
		SELECT
			MIN(documento_assinante1.COD_DOCUMENTO_ASSINANTE)
		FROM
			DBO_PACTO..TB_DOCUMENTO_ASSINANTE AS documento_assinante1  WITH (NOLOCK)
		WHERE
			documento_assinante1.COD_STATUS_ASSINATURA = 1	
		GROUP BY
			documento_assinante1.COD_DOCUMENTO
	)
ORDER BY
	documento.DAT_INC DESC		
END

GO

