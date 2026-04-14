CREATE TABLE IF NOT EXISTS phone_numbers (
    id SERIAL PRIMARY KEY,
    phone_number VARCHAR(20) UNIQUE NOT NULL,
    CONSTRAINT phone_format CHECK (phone_number ~ '^\+\d{10,15}$')
);