<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
				xmlns:p="http://tempuri.org/data5.xsd">
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				<title>Phieu mua hang</title>
			</head>
			<body>
				<h1>Danh muc hoa don ban hang</h1>
				<xsl:for-each select="p:dsphieu/p:phieu">
					<h3>
						Hoa don: <xsl:value-of select="p:hoadon"/>
					</h3>
					<h3>
						Ngay ban: <xsl:value-of select="p:ngayban"/>
					</h3>
					<h3>
						Loai hang: <xsl:value-of select="p:loaihang"/>
					</h3>

					<table>
						<tr>
							<th>STT</th>
							<th>Ma Hang</th>
							<th>Ten Hang</th>
							<th>So Luong</th>
							<th>Don Gia</th>
							<th>Thanh Tien</th>
						</tr>
						<xsl:for-each select="p:hang">
							<tr>
								<td>
									<xsl:value-of select="position()"/>
								</td>
								<td>
									<xsl:value-of select="p:mahang"/>
								</td>
								<td>
									<xsl:value-of select="p:tenhang"/>
								</td>
								<td>
									<xsl:value-of select="p:soluong"/>
								</td>
								<td>
									<xsl:value-of select="p:dongia"/>
								</td>
								<td>
									<xsl:value-of select="p:thanhtien"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>

					<h3>
						Nguoi giao: <xsl:value-of select="p:nguoigiao"/>
					</h3>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
