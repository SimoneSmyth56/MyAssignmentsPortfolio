package librarymanagementsystem;

import java.time.LocalDateTime;
import java.util.*;

public class Book {

    String title;
    String author;
    String isbn;
    boolean isAvailable;

    LocalDateTime checkedOutDate;

    public Book(String title, String author, String isbn, boolean isAvailable, LocalDateTime checkedOutDate) {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.isAvailable = isAvailable;
        this.checkedOutDate = checkedOutDate;

    }
    
    public Book () {
        
    }

    // public static <dataType> methodName
    public static List<Book> bookList() {

        List<Book> bookListItem = new ArrayList<>();
//        bookListItem.add(new Book("The Lost Kingdom", "Sarah Thompson", "978-1-234567-89-0", true));
//        bookListItem.add(new Book("Echoes of Destiny", "Jonathan Anderson", "978-0-987654-32-1", true));
//        bookListItem.add(new Book("Maths Made Easy", "John Davis", "978-1-234567-89-2", true));
//        bookListItem.add(new Book("History Unfolded", "Michael Roberts", "978-6-543210-98-9", true));
//        bookListItem.add(new Book("Midnight Serenade", "Laura Evans", "978-9-876543-21-0", true));
//        bookListItem.add(new Book("Empires of the Ancient World", "Michael Brown", "978-6-543210-98-8", true));
//        bookListItem.add(new Book("Science Explorations", "Sarah Adams", "978-0-987654-32-3", true));

        return bookListItem;

    }

}
