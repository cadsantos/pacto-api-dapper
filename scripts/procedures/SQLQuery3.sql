DECLARE @IDUsuario AS INT
SET @IDUsuario = 475

--aguardando assinatura

SELECT
	Documento.COD_DOCUMENTO,
	Documento.KEY_DOCUMENTO,
	Documento.TXT_NOME,
	Documento.TXT_DESCRICAO
FROM
	TB_DOCUMENTO AS Documento
INNER JOIN
	TB_DOCUMENTO_ASSINANTE AS DocumentoAssinante ON DocumentoAssinante.COD_DOCUMENTO = Documento.COD_DOCUMENTO
WHERE
	Documento.COD_STATUS_DOCUMENTO = 2
	AND Documento.DAT_EXCLUSAO IS NULL
	AND @IDUsuario = (
		SELECT
			TOP 1 DocumentoAssinante_1.COD_ASSINANTE
		FROM
			TB_DOCUMENTO_ASSINANTE AS DocumentoAssinante_1
		WHERE
			DocumentoAssinante_1.COD_STATUS_ASSINATURA = 2
			AND DocumentoAssinante_1.COD_DOCUMENTO = Documento.COD_DOCUMENTO			
		ORDER BY
			DocumentoAssinante_1.COD_DOCUMENTO_ASSINANTE ASC
	)
GROUP BY
	Documento.COD_DOCUMENTO,
	Documento.KEY_DOCUMENTO,
	Documento.TXT_NOME,
	Documento.TXT_DESCRICAO

--USE [DBO_PACTO]
--GO
--CREATE NONCLUSTERED INDEX [IX_TB_DOCUMENTO_COD_STATUS_DOCUMENTO_DAT_EXCLUSAO]
--ON [dbo].[TB_DOCUMENTO] ([COD_STATUS_DOCUMENTO],[DAT_EXCLUSAO])
--INCLUDE ([COD_DOCUMENTO],[KEY_DOCUMENTO],[TXT_NOME],[TXT_DESCRICAO])
--GO


