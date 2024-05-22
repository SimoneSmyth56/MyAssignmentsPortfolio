package librarymanagementsystem;

import java.time.*;
import java.util.*;

public class LibraryManagementSystem extends Thread {

    public static List<Book> booksList = Book.bookList(); // List to store books
    public static List<Member> memberList = Member.memberList(); // List to store members
    private static Scanner input = new Scanner(System.in); // Scanner for user input

    public static void main(String[] args) {

        FileManager fileManager = new FileManager();

        memberList = fileManager.MemberFileRead();
        booksList = fileManager.BookFileRead();
        fileManager.MemberBorrowBooksRead();

        FinesUpdater finesUpdater = new FinesUpdater();
        Thread finesThread = new Thread(finesUpdater);
        finesThread.start();

        FinesNotifier finesNotifier = new FinesNotifier();
        Thread notifyThread = new Thread(finesNotifier);
        notifyThread.start();

        int optionSelected; // Variable to store user's menu choice
        int subMenuOption; // Variable to store user's submenu choice

        while (true) {
            try {
                //Main Menu 
                System.out.println("|=========================================|");
                System.out.println("         Welcome to the Library!");
                System.out.println("|=========================================|");
                System.out.println(" ");
                System.out.println("Please choose an option:");
                System.out.println(" ");
                System.out.println("1.View all books");
                System.out.println("2.Search books");
                System.out.println("3.Check-out book");
                System.out.println("4.Return a book");
                System.out.println("5.Add new book");
                System.out.println("6.Remove a book");
                System.out.println("7.View all members");
                System.out.println("8.Add new member");
                System.out.println("9.Remove a member");
                System.out.println("10.Check due dates & fines");
                System.out.println("11.Manage Notifications");
                System.out.println("0.Exit Program");
                optionSelected = input.nextInt(); // Read user's choice

                switch (optionSelected) {

                    case 1:
                        // View all books
                        do {
                            // Display information for each book
                            for (Book book : booksList) { // Loop through books list
                                System.out.println("|=========================================|");
                                System.out.println("   Title: " + book.title);
                                System.out.println("   Author: " + book.author);
                                System.out.println("   ISBN: " + book.isbn);
                                System.out.println("   Available: " + book.isAvailable);
                                System.out.println("|=========================================|");
                            }

                            System.out.println(" ");
                            System.out.println("Enter 0 to return to the Main Menu");
                            subMenuOption = input.nextInt(); // Prompt user to return to main menu

                        } while (subMenuOption != 0);
                        break;

                    case 2:
                        // Search for a book
                        do {
                            System.out.println("Enter the title or author of the book you are looking for: ");
                            String bookSearched = input.next().toLowerCase();

                            for (Book book : booksList) {
                                if (book.title.toLowerCase().contains(bookSearched) || book.author.toLowerCase().contains(bookSearched)) {
                                    System.out.println("|=========================================|");
                                    System.out.println("   Title: " + book.title);
                                    System.out.println("   Author: " + book.author);
                                    System.out.println("   ISBN: " + book.isbn);
                                    System.out.println("   Available: " + book.isAvailable);
                                    System.out.println("|=========================================|");
                                }
                            }

                            System.out.println(" ");
                            System.out.println("Enter 1 to search for another book or enter 0 to return to the main menu");
                            subMenuOption = input.nextInt();

                        } while (subMenuOption != 0);
                        break;

                    case 3:
                        // Check out a book
                        do {
                            System.out.println("Please enter your member ID:"); // Member ID is used to allocate member in the member list
                            int memberId = input.nextInt();

                            boolean memberExists = false; //Boolean to check is the member is on the member list

                            for (Member member : memberList) {
                                if (memberId == member.ID) {
                                    memberExists = true;
                                    break;
                                }
                            }

                            if (memberExists) {
                                System.out.println("List of Books:");
                                System.out.println("");

                                for (Book book : booksList) {
                                    System.out.println("|=========================================|");
                                    System.out.println("   Title: " + book.title);
                                    System.out.println("   Author: " + book.author);
                                    System.out.println("   ISBN: " + book.isbn);
                                    System.out.println("   Available: " + book.isAvailable);
                                    System.out.println("|=========================================|");
                                }

                                // Prompt for book to check out
                                System.out.println("Please enter the title of the book you would like to check out? ");
                                input.nextLine();
                                String bookCheckOut = input.nextLine().toLowerCase(); // Read the book title

                                for (Book book : booksList) {
                                    if (book.title.toLowerCase().contains(bookCheckOut) && book.isAvailable) {
                                        assert book.isAvailable : "Book should be available before checkout"; // Assertion
                                        book.isAvailable = false; // Mark the book as unavailable
                                        book.checkedOutDate = LocalDateTime.now(); //Update the date the book has been checked out
                                        fileManager.BookFileWrite(); //Write this action to the Books file for persistance

                                        for (Member member : memberList) {
                                            if (memberId == member.ID) {
                                                member.borrowedBooks.add(book);
                                                fileManager.TransactLogFileWrite("Checked out book" + book.title, "By Member" + member.name); //Update the transaction logs
                                                fileManager.MemberBorrowBooksWrite(); //Write this action to the Members file for persistance
                                                System.out.println("You have checked out" + " " + book.title);
                                                break;
                                            }
                                        }
                                    }

                                }

                            } else {
                                System.out.println("Member does not exist. Please check the name and surname or register as a new member.");
                            }

                            System.out.println(" ");
                            System.out.println("Enter 1 to check out another book or enter 0 to return to the main menu");
                            subMenuOption = input.nextInt();

                        } while (subMenuOption != 0);
                        break;

                    case 4:
                        // Return out a book 
                        LocalDateTime returnedDate = LocalDateTime.now();

                        do {
                            System.out.println("Please enter your member ID:");
                            int memberId = input.nextInt();

                            for (Member member : memberList) {
                                if (memberId == member.ID) {

                                    String borrowedBookString = "";

                                    for (Book book : member.borrowedBooks) {
                                        borrowedBookString += book.title + "|";
                                    }

                                    System.out.println("Hello" + " " + member.name + " " + member.surname);
                                    System.out.println("");
                                    System.out.println("Please enter the title of the book you would like to return? ");
                                    System.out.println(borrowedBookString);
                                    input.nextLine();
                                    String bookReturn = input.nextLine().toLowerCase(); // Read the book title

                                    for (Book book : booksList) {
                                        if (book.title.toLowerCase().contains(bookReturn) && !book.isAvailable) {
                                            if (member.borrowedBooks.contains(book)) {
                                                member.borrowedBooks.remove(book);
                                                fileManager.MemberBorrowBooksWrite();

                                                book.isAvailable = true; // Set available only if member borrowed it
                                                book.checkedOutDate = null; // Reset checkout date
                                                // Update transaction and member files
                                                fileManager.BookFileWrite();
                                                fileManager.TransactLogFileWrite("Book returned" + book.title, "Return date" + returnedDate); //Update the transaction logs
                                                
                                                System.out.println("You have returned " + book.title);
                                                break; // Exit member loop after successful return
                                            } else {
                                                System.out.println("You did not borrow this book");
                                            }

                                        }
                                    }

                                }
                            }
                            System.out.println(" ");
                            System.out.println("Enter 1 to return another book or enter 0 to return to the main menu");
                            subMenuOption = input.nextInt();

                        } while (subMenuOption != 0);
                        break;

                    case 5:
                        // Add a book
                        do {
                            System.out.println("Enter the details of the book:");
                            input.nextLine(); // Consumes the newline character so helps break up the input
                            System.out.print("Title: ");
                            String newTitle = input.nextLine();
                            System.out.print("Author: ");
                            String newAuthor = input.nextLine();
                            boolean isAvailable = true;

                            String isbnRegex = "^\\d{3}-\\d-\\d{6}-\\d{2}-\\d$"; //ISBN number must be a 13 digit number seperated by "-"
                            boolean validIsbn = false;
                            String newIsbn = "";

                            do {
                                System.out.print("ISBN (format xxx-x-xxxxxx-xx-x): ");
                                newIsbn = input.nextLine();

                                if (newIsbn.matches(isbnRegex)) {
                                    validIsbn = true;
                                } else {
                                    System.out.println("ISBN is invalid. Please re-enter in correct format i.e. (format xxx-x-xxxxxx-xx-x)");
                                }
                            } while (!validIsbn);

                            Book newBook = new Book(newTitle, newAuthor, newIsbn, isAvailable, null);
                            booksList.add(newBook); // Adds the new book to the global list

                            fileManager.BookFileWrite();
                            System.out.println("Book has been added.");

                            System.out.println(" ");
                            System.out.println("Enter 1 to add another book or enter 0 to return to the main menu");
                            subMenuOption = input.nextInt();
                        } while (subMenuOption != 0);
                        break;

                    case 6:
                        //Remove a book
                        do {
                            System.out.println("Enter the details of the book you want to remove:");
                            input.nextLine(); // Consumes the newline character so helps break up the input
                            System.out.print("Title: ");
                            String removeTitle = input.nextLine().toLowerCase();

                            String isbnRegex = "^\\d{3}-\\d-\\d{6}-\\d{2}-\\d$"; //ISBN number must be a 13 digit number seperated by "-"
                            boolean validIsbn = false;
                            String removeIsbn = "";

                            do {
                                System.out.print("ISBN (format xxx-x-xxxxxx-xx-x): ");
                                removeIsbn = input.nextLine();

                                if (removeIsbn.matches(isbnRegex)) {
                                    validIsbn = true;
                                } else {
                                    System.out.println("ISBN is invalid. Please re-enter in correct format i.e. (format xxx-x-xxxxxx-xx-x)");
                                }
                            } while (!validIsbn);

                            for (Book book : booksList) {

                                if (book.title.toLowerCase().contains(removeTitle) && book.isbn.contains(removeIsbn)) {
                                    booksList.remove(book);
                                    
                                    break;
                                }

                            }
                            fileManager.BookFileWrite();
                            System.out.println("Book has been removed.");
                            System.out.println(" ");
                            System.out.println("Enter 1 to remove another book or enter 0 to return to the main menu");
                            subMenuOption = input.nextInt();
                        } while (subMenuOption != 0);
                        break;

                    case 7:
                        // View all members
                        do {
                            // Display information for each member
                            for (Member member : memberList) {
                                String borrowedBookString = "";

                                for (Book book : member.borrowedBooks) {
                                    borrowedBookString += book.title + "||";
                                }
                                System.out.println("|=========================================|");
                                System.out.println("   Name & Surname: " + member.name + " " + member.surname);
                                System.out.println("   Email Address: " + member.emailAddress);
                                System.out.println("   Books Borrowed: " + borrowedBookString);
                                System.out.println("   Fines: " + member.totalFines);
                                System.out.println("|=========================================|");
                            }

                            System.out.println(" ");
                            System.out.println("Enter 0 to return to the main menu");
                            subMenuOption = input.nextInt();
                        } while (subMenuOption != 0);

                        break;

                    case 8:
                        // Add a member
                        do {
                            System.out.println("Enter the details of the new member:");
                            input.nextLine();
                            System.out.print("Name: ");
                            String newMemberName = input.next();
                            System.out.print("Surname: ");
                            String newMemberSurname = input.next();
                            int totalFines = 0;

                            String emailRegex = "^(?=.{1,64}@)[A-Za-z0-9_-]+(\\.[A-Za-z0-9_-]+)*@"
                                    + "[^-][A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z]{2,})$"; //email should include @, a "dot" and domain suffix 
                            boolean validEmail = false;
                            String newMemberEmail = "";

                            do {
                                System.out.print("Email address: ");
                                newMemberEmail = input.next();

                                if (newMemberEmail.matches(emailRegex)) {
                                    validEmail = true;
                                } else {
                                    System.out.println("Email is invalid. Please re-enter.");
                                }
                            } while (!validEmail);

                            Member lastMember = memberList.getLast();

                            int newMemberID = lastMember.ID + 1;
                            Member newMembers = new Member(newMemberID, newMemberName, newMemberSurname, newMemberEmail, totalFines);

                            memberList.add(newMembers);

                            fileManager.MemberFileWrite();
                            System.out.println("Member has been added");

                            System.out.println(" ");
                            System.out.println("Enter 0 to return to the main menu");
                            subMenuOption = input.nextInt();
                        } while (subMenuOption != 0);
                        break;

                    case 9:
                        // Remove a member
                        do {
                            System.out.println("Enter the details of the new member:");
                            input.nextLine();
                            System.out.print("Name: ");
                            String removeMemberName = input.next();
                            System.out.print("Surname: ");
                            String removeMemberSurname = input.next();

                            for (Member member : memberList) {
                                if (member.name.toLowerCase().contains(removeMemberName) && member.surname.toLowerCase().contains(removeMemberSurname)) {
                                    memberList.remove(member);
                                    fileManager.MemberFileWrite();
                                    break;
                                    
                                }
                            }

                            
                                    
                            System.out.println("Member has been removed");

                            System.out.println(" ");
                            System.out.println("Enter 0 to return to the main menu");
                            subMenuOption = input.nextInt();
                        } while (subMenuOption != 0);
                        break;

                    case 10:
                        // Check due dates & fines
                        do {
                            System.out.println("Please enter your member ID:"); // Member ID Input is used to allocate member in the member list
                            int memberId = input.nextInt();

                            for (Member member : memberList) {
                                if (memberId == member.ID) {
                                    System.out.println("Hello" + " " + member.name);
                                    if (member.totalFines > 0) {
                                        System.out.println("Fine amount payable: R" + member.totalFines);

                                    } else {
                                        System.out.println("There is no outstanding fines");
                                    }

                                    break;
                                }
                            }

                            System.out.println(" ");
                            System.out.println("Enter 0 to return to the main menu");
                            subMenuOption = input.nextInt();
                        } while (subMenuOption != 0);
                        break;

                    case 11:
                        //Manage notifications

                        do {
                            finesUpdater.manageFinesNotifications(); //displays message confirming that the fines have been updated
                            finesNotifier.manageEmailNotifications(); //displays message confirming that the emails have been sent

                            System.out.println(" ");
                            System.out.println("Enter 0 to return to the main menu");
                            subMenuOption = input.nextInt();
                        } while (subMenuOption != 0);
                        break;

                    case 0:
                        // Exit the program
                        System.out.println("Exiting the program. Goodbye!");
                        input.close(); // Close the scanner to release resources
                        System.exit(0);
                        break;

                    default:
                        System.out.println("Invalid option. Please try again.");
                        break;
                }

            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter a valid integer.");
                input.nextLine(); // Clear the input buffer
            }

        }
    }
}
