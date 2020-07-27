<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
	xmlns:s="http://tempuri.org/test-form.xsd">
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				<title>Test 1</title>
				<style>
					body {
					padding: 50px 50px;
					}
					table {
					border-collapse: collapse;
					text-align: center;
					}
					table, tr, th, td {
					border: 1px solid black;
					}
					th, td {
					padding: 5px;
					}
				</style>
			</head>
			<body>
				<h1>Danh sach thu vien sach</h1>
				<hr/>
				<xsl:for-each select="s:dscuonsach/s:cuonsach">
					<p>
						Ma sach: <xsl:value-of select="@masach"/>
					</p>
					<p>
						Ten sach: <xsl:value-of select="s:tensach"/>
					</p>
					<p>
						Ma xuat ban: <xsl:value-of select="s:maxuatban"/>
					</p>
					<p>
						Nha xuat ban: <xsl:value-of select="s:nhaxuatban"/>
					</p>
					<p>
						So trang: <xsl:value-of select="s:sotrang"/>
					</p>
					<p>
						Gia tien: <xsl:value-of select="s:giatien"/>
					</p>
					<table>
						<tr>
							<th>STT</th>
							<th>Ho ten</th>
							<th>Tuoi</th>
							<th>Dia chi</th>
							<th>Dien thoai</th>
						</tr>
						<xsl:for-each select="s:tacgia">
							<tr>
								<td>
									<xsl:value-of select="position()"/>
								</td>
								<td>
									<xsl:value-of select="s:hoten"/>
								</td>
								<td>
									<xsl:value-of select="s:tuoi"/>
								</td>
								<td>
									<xsl:value-of select="s:diachi"/>
								</td>
								<td>
									<xsl:value-of select="s:dienthoai"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
					<hr/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
