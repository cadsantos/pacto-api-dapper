DECLARE @IDUsuario AS INT
SET @IDUsuario = 475

-- aguardando finalizacao manual
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
	AND Documento.COD_USUARIO = @IDUsuario
	AND Documento.COD_TIPO_FINALIZACAO = 2
	AND Documento.DAT_EXCLUSAO IS NULL	
	AND Documento.COD_DOCUMENTO = ALL(
		SELECT
			DocumentoAssinante_1.COD_DOCUMENTO
		FROM
			TB_DOCUMENTO_ASSINANTE AS DocumentoAssinante_1
		WHERE
			DocumentoAssinante_1.COD_STATUS_ASSINATURA = 1
			AND DocumentoAssinante_1.COD_DOCUMENTO = Documento.COD_DOCUMENTO			
	)
GROUP BY
	Documento.COD_DOCUMENTO,
	Documento.KEY_DOCUMENTO,
	Documento.TXT_NOME,
	Documento.TXT_DESCRICAO


