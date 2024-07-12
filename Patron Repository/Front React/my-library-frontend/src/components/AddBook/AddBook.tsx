import React, { useState } from 'react';
import axios from 'axios';
import { Book } from "../../interfaces/Book";

export const AddBook = () => {
    const [book, setBook] = useState<Partial<Book>>({});

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        if (!book.title || !book.author) {
            return;
        }
        try {
            const response = await axios.post('http://localhost:5000/api/books', book);
            setBook({});
            console.log(response)
            // Handle response or redirect
        } catch (error) {
            console.error('There was an error adding the book', error);
        }
    };

    return (
        <div>
            <h2>Add Book</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Title:</label>
                    <input 
                        type="text" 
                        value={book.title || ''} 
                        onChange={e => setBook(prev => ({ ...prev, title: e.target.value }))} 
                    />
                </div>
                <div>
                    <label>Author:</label>
                    <input 
                        type="text" 
                        value={book.author || ''} 
                        onChange={e => setBook(prev => ({ ...prev, author: e.target.value }))} 
                    />
                </div>
                <button type="submit">Add</button>
            </form>
        </div>
    );
};

