Projeyi geliþtirirken N-Tier Architecture,.Net Core,Wep API,Swagger,JWT kullandým.Database'imi oluþtururken MsSql Kullandým.
Projenin düzgün bir þekilde çalýþmasý için MsSql üzerinde çalýþmasý gerekir.Bunun için yapýlmasý gereken adýmlar þu þekildedir.
1)MsSql Connection String data source'unuzu doðru bir þekilde projenin "appsettings.json/satýr 14" ve "DataAccessLayer/ProjectDbContext/satýr 27" 
satýrlarýndaki data source kýsýmlarýna uygulamanýz gerekir.
2)Package Manager console'a girerek "update-database" komutunu yazýp enter demeniz gerekir.

Bunlarý yaptýktan sonra uygulamayý çalýþtýrýp test edebilirsiniz.

Register Yaparken Dikkat Edilmesi Gerekenler
-Þifre oluþtururken bir büyük harf,bir küçük harf,bir sayý ve bir özel karakter girilmesi gerekmektedir...