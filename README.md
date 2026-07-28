# Library Management System

A simple desktop library management app built with C# and WinForms. It has two screens: a login form and a book management form, both talking directly to a SQL Server database.

## What it does

**Login (`FormGiris`)**
- Checks the entered username against the `TableKutuphaneYoneticileri` table and compares the stored password.
- Shows an error message if the username/password fields are empty or the credentials don't match, and clears the fields on failure.
- On success, opens the books form and hides the login window.

**Books (`FormKitaplar`)**
- Lists all books from `TableKitaplar` in a grid on load.
- Add a book: title, author first/last name, ISBN, and a category code (new books are marked as available).
- Update the selected book's details.
- Search books by title, author, ISBN, category code, or borrower, matching from the start of each field.
- Check out a book: sets the borrower name, borrow date, and marks it unavailable.
- Return a book: clears the borrower and borrow date, marks it available again.
- Calculate a late fee: 1 unit per day once a book has been borrowed for more than 10 days.
- Delete the selected book.
- Clear the form fields.

## Tech stack

- .NET 6 (`net6.0-windows`), WinForms
- `System.Data.SqlClient` for database access
- SQL Server (the connection string points at a local `SQLEXPRESS` instance, database `DbYTAKutuphane`)

## Running it

1. Set up a local SQL Server (or SQL Server Express) instance with a database named `DbYTAKutuphane`, containing `TableKutuphaneYoneticileri` (with `KullaniciAdi`/`Sifre` columns) and `TableKitaplar` (with the book fields referenced above).
2. Open `KutuphaneYonetimSistemi.csproj` in Visual Studio and run it (F5), or from the command line:
   ```
   dotnet run
   ```
3. Log in with a username/password that exists in `TableKutuphaneYoneticileri`.

## Notes

This was built as a learning project, so a few things are worth knowing before using it for anything real: passwords are stored and compared in plain text, and the search query builds SQL with string concatenation rather than parameters. Not production-ready as-is.
