CREATE TABLE public.users (
	id serial4 NOT NULL,
	"name" varchar(50) NULL,
	username varchar(50) NULL,
	email varchar(50) NULL,
	street varchar(50) NULL,
	city varchar(50) NULL,
	CONSTRAINT users_pkey PRIMARY KEY (id)
);