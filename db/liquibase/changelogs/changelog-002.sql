CREATE TABLE public.address (
	user_id int NOT NULL,
	street varchar(50) NULL,
	city varchar(50) NULL,
	CONSTRAINT address_pkey PRIMARY KEY (user_id),
    CONSTRAINT fk_users FOREIGN KEY(user_id) REFERENCES users(id)
);