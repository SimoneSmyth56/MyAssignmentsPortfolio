package librarymanagementsystem;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;

public class FinesNotifier implements Runnable {
    
    boolean emailsUpdated = false;

    @Override
    public void run() {
       
        while (true) {
            
            try {
                for (Member member : LibraryManagementSystem.memberList) {

                    if (member.totalFines > 0) {
                        BufferedWriter writer = new BufferedWriter(new FileWriter("/Users/simonesmyth/NetBeansProjects/LibraryManagementSystem/notifications/" + member.ID + ".txt"));

                        writer.write("From: librarymanagement@outlook.com \n");
                        writer.write("To: " + member.emailAddress + "\n");
                        writer.write("Subject: Overdue Fine Notice\n");
                        writer.newLine();
                        writer.write("Dear " + member.name + " " + member.surname + ",\n");
                        writer.newLine();
                        writer.write("The current fine amount is: R" + member.totalFines + "\n");
                        writer.newLine();
                        writer.write("Please return the book or make a payment at your earliest convenience.\n");
                        writer.newLine();
                        writer.write("Sincerely,\n");
                        writer.write("The Library\n");
                        writer.newLine();
                        writer.close(); 
                        
                        emailsUpdated = true;
                    }
                }
                Thread.sleep(600000);
            } catch (IOException | InterruptedException e) {
                
            }
        }
        
    }
    public void manageEmailNotifications() {
        
         if (emailsUpdated) {
            System.out.println("Email has been sent");
            emailsUpdated = false; // Reset the flag after displaying the message
        } else {
            System.out.println("No recent notifications sent.");
        }
        
    }
}