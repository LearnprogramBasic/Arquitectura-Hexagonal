import { useEffect, useState } from "react"
import { Book } from "../../interfaces/Book";
import axios from 'axios';

export const BookList = () => {

    const[ books, setBooks] = useState<Book[]>([]);
    useEffect(() => {
        const fetchBooks = async () => {
            try {
                const response = await axios.get<Book[]>('http://localhost:5000/api/books');
                setBooks(response.data);
            } catch (error) {
                console.error('There was an error fetching the books', error);
            }
        };

        fetchBooks();
    }, []);

    return (
        <div>
            <h2>Book List</h2>
            <ul>
                {books.map(book => (
                    <li key={book.id}>{book.title} by {book.author}</li>
                ))}
            </ul>
        </div>
    );
};

