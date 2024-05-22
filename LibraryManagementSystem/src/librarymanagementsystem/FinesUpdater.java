package librarymanagementsystem;

import java.time.*;

public class FinesUpdater implements Runnable {

    boolean finesUpdated = false;

    @Override
    public void run() {
        try {
            System.out.println("Thread started");

            while (true) {

                LocalDateTime currentDate = LocalDateTime.now();

                for (Member member : LibraryManagementSystem.memberList) {

                    if (!member.borrowedBooks.isEmpty()) {

                        int memberTotalFines = 0;

                        for (Book borrowedBook : member.borrowedBooks) {
                            LocalDateTime checkOutDate = borrowedBook.checkedOutDate;

                            if (checkOutDate == null) {
                                continue;
                            }

                            // Calculate the difference between returnDateActual and returnDateExpected
                            Duration duration = Duration.between(checkOutDate, currentDate);

                            long overDueDays = duration.toSeconds(); //For Testing purposes

                            //long overDueDays = duration.toDays();
                            //^^this is the actual method invocation I want to use, bit I'm temporarily using toSeconds() for testing purposes instead of toDays() to verify certain functionality. 
                            
                            // Calculate fine amount based on the number of days overdue
                            long fineAmount;

                            //loan period 10 days
                            if (overDueDays <= 10) {

                                fineAmount = 0; // No fine for books returned on time

                            } else if (overDueDays <= 20) {
                                fineAmount = 20 * overDueDays; // R20 fine per day for 11-20 days overdue

                            } else if (overDueDays <= 30) {
                                fineAmount = 30 * overDueDays; // R30 fine per day for 21-30 days overdue

                            } else {
                                fineAmount = 40 * overDueDays; // R40 fine per day for any days more than 31 days overdue
                            }

                            if (fineAmount > 0) {

                                memberTotalFines += fineAmount;
                                finesUpdated = true;

                            }

                        }
                        member.totalFines += memberTotalFines; //Add the fine amount to the members existing total fines payable
                    }
                }
                Thread.sleep(10000);
            }

        } catch (InterruptedException e) {

        }
    }

    //Method to display a message in the "Manage Notification" case
    public void manageFinesNotifications() {

        if (finesUpdated) {
            System.out.println("Fines have been updated");
            finesUpdated = false; // Reset the flag after displaying the message
        } else {
            System.out.println("No recent updates.");
        }

    }

}

