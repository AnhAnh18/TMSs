SELECT MONTH(AdjustDate),YEAR(AdjustDate) FROM Adjust GROUP BY MONTH(AdjustDate),YEAR(AdjustDate) ORDER BY MONTH(AdjustDate) DESC,YEAR(AdjustDate) DESC

SELECT ROW_NUMBER() OVER (ORDER BY A.AdjustID),A.AdjustID,CONVERT(VARCHAR(10), AdjustDate, 103),CONVERT(VARCHAR(10), EnterDate, 103),AD.DAcc,AD.CAcc,D_CustID,C_CustID,AccAmt,EmployeeID,AD.Descr FROM Adjust A 
																																																INNER JOIN AdjustDet AD ON A.AdjustID = AD.AMainID
																																																WHERE MONTH(A.AdjustDate) = 6 AND YEAR (A.AdjustDate) = 2016 AND MONTH(A.EnterDate) = 6 AND YEAR (A.EnterDate) = 2016 ORDER BY A.AdjustID DESC
select ROW_NUMBER() over(order by adjustid) from Adjust

--Điều chỉnh
SELECT ROW_NUMBER() OVER (ORDER BY A.AdjustID DESC),A.AdjustID,CONVERT(VARCHAR(10), AdjustDate, 103),CONVERT(VARCHAR(10), EnterDate, 103),AD.DAcc,AD.CAcc,KH.CustName,MTK.CustName,AccAmt,EmployeeID,AD.Descr FROM AdjustDet AD
																																																	INNER JOIN Adjust A  ON A.AdjustID = AD.AMainID 
																																																		INNER JOIN Customer KH ON AD.D_CustID = KH.CustID ,
																																																		(SELECT KH.CustID,KH.CustName,A.AdjustID,AD.AMainID FROM AdjustDet AD INNER JOIN Customer KH ON AD.C_CustID = KH.CustID INNER JOIN Adjust A ON A.AdjustID = AD.AMainID) AS MTK
																																																		WHERE MTK.AdjustID = A.AdjustID AND MTK.CustID = AD.C_CustID AND MONTH(A.AdjustDate) = 6 AND YEAR (A.AdjustDate) = 2016 AND MONTH(A.EnterDate) = 6 AND YEAR (A.EnterDate) = 2016 ORDER BY A.AdjustID DESC


SELECT ROW_NUMBER() OVER (ORDER BY A.AdjustID DESC),A.AdjustID,CONVERT(VARCHAR(10), AdjustDate, 103),CONVERT(VARCHAR(10), EnterDate, 103),AD.DAcc,AD.CAcc,KH.CustName,MTK.CustName,AccAmt,EmployeeID,AD.Descr FROM AdjustDet AD INNER JOIN Adjust A  ON A.AdjustID = AD.AMainID INNER JOIN Customer KH ON AD.D_CustID = KH.CustID ,(SELECT KH.CustID,KH.CustName,A.AdjustID,AD.AMainID FROM AdjustDet AD INNER JOIN Customer KH ON AD.C_CustID = KH.CustID INNER JOIN Adjust A ON A.AdjustID = AD.AMainID ) AS MTK WHERE MTK.AdjustID = AD.AMainID AND MTK.CustID = AD.C_CustID AND MONTH(A.AdjustDate) = 6 AND YEAR (A.AdjustDate) = 2016 AND MONTH(A.EnterDate) = 6 AND YEAR (A.EnterDate) = 2016 ORDER BY A.AdjustID DESC


SELECT AD.DAcc,AD.D_CustID,KH.CustName,AD.CAcc,C_CustID,C_CustID as tenk,AccAmt,AD.Descr FROM AdjustDet AD INNER JOIN Adjust A  ON A.AdjustID = AD.AMainID INNER JOIN Customer KH ON AD.D_CustID = KH.CustID WHERE MONTH(A.AdjustDate) = 6 AND YEAR (A.AdjustDate) = 2016 AND MONTH(A.EnterDate) = 6 AND YEAR (A.EnterDate) = 2016 ORDER BY A.AdjustID DESC


--Nhân viên
SELECT NV.SlsPerID,NV.SlsPerName,NV.Address,NV.CMT,Phone,SlsPerDescr FROM SalesPerson NV

--Khách hàng
SELECT CustID,CustName,CustType,KH.Address,Fax,VATCode FROM CUSTOMER KH where CustID = N'CN0023'
SELECT * FROM CUSTOMER KH where CustID = N'CN0023'
SELECT CustID FROM  Customer

UPDATE Customer SET CustName = N'',Address = N'',CMT = N'',Phone = N'',Fax = N'',VATCode = N'',CustType = N'',Status = N'',CustDescr = N''
INSERT INTO Customer(CustID,CustName,Address,CMT,Phone,Fax,VATCode,CustDescr)  VALUES N''






--chi tiết điều chỉnh

SELECT SUM(AccAmt) FROM AdjustDet WHERE AMainID = 332


select * from adjust
select * from users
select * from SalesPerson