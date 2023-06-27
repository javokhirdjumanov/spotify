CREATE TABLE public.hl_otp_code
(
    id serial integer NOT NULL,
    code character varying(10) COLLATE pg_catalog."default" NOT NULL,
    created_at timestamp without time zone NOT NULL,
    status_id integer NOT NULL,
    user_id integer NOT NULL,
    CONSTRAINT hl_otp_code_pkey PRIMARY KEY (id),
    CONSTRAINT hl_otp_code_status_id_fkey FOREIGN KEY (status_id)
        REFERENCES public.enum_otp_code_status (id),
    CONSTRAINT hl_otp_code_user_id_fkey FOREIGN KEY (user_id)
        REFERENCES public.hl_user (id)
)