docker build --pull -t recruiting-takehome .  \
&& docker run --name get-load --rm -it -p 5000:5000 -p 5001:5001 recruiting-takehome
