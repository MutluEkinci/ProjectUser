Projeyi geli�tirirken N-Tier Architecture,.Net Core,Wep API,Swagger,JWT kulland�m.Database'imi olu�tururken MsSql Kulland�m.
Projenin d�zg�n bir �ekilde �al��mas� i�in MsSql �zerinde �al��mas� gerekir.Bunun i�in yap�lmas� gereken ad�mlar �u �ekildedir.
1)MsSql Connection String data source'unuzu do�ru bir �ekilde projenin "appsettings.json/sat�r 14" ve "DataAccessLayer/ProjectDbContext/sat�r 27" 
sat�rlar�ndaki data source k�s�mlar�na uygulaman�z gerekir.
2)Package Manager console'a girerek "update-database" komutunu yaz�p enter demeniz gerekir.

Bunlar� yapt�ktan sonra uygulamay� �al��t�r�p test edebilirsiniz.

Register Yaparken Dikkat Edilmesi Gerekenler
-�ifre olu�tururken bir b�y�k harf,bir k���k harf,bir say� ve bir �zel karakter girilmesi gerekmektedir...