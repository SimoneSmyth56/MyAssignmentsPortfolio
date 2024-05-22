package librarymanagementsystem;

import java.util.*;

public class Member {
    
    int ID = 0;
    String name;
    String surname;
    String emailAddress;
    List<Book> borrowedBooks = new ArrayList<>();
    int totalFines;

    public Member(int ID, String name, String surname, String emailAddress, int totalFines) {
        this.ID = ID;
        this.name = name;
        this.surname = surname;
        this.emailAddress = emailAddress;
        this.totalFines = totalFines;

    }
    
    public Member() {
        
    }

    public static List<Member> memberList() {

        List<Member> memberListItem = new ArrayList<>();
//        memberListItem.add(new Member(1, "John", "Smith", "john.s@yahoo.com", 0));
//        memberListItem.add(new Member(2, "Alice", "Johnson", "alice.johnson@example.com", 0));
//        memberListItem.add(new Member(3, "Michael", "Brown", "michael.brown@example.com", 0));
//        memberListItem.add(new Member(4, "Emily", "Rodriguez", "emily.rodriguez@example.com", 0));
//        memberListItem.add(new Member(5, "Daniel", "Martinez", "daniel.martinez@example.com", 0));
//        memberListItem.add(new Member(6, "Olivia", "Davis", "olivia.davis@example.com", 0));
//        memberListItem.add(new Member(7, "William", "Wilson", "william.wilson@example.com", 0));
//        memberListItem.add(new Member(8, "Sophia", "Taylor", "sophia.taylor@example.com", 0));
//        memberListItem.add(new Member(9,"James", "Anderson", "james.anderson@example.com", 0));
//        memberListItem.add(new Member(10, "Isabella", "Thomas", "isabella.thomas@example.com", 0));

        return memberListItem;

    }
}
