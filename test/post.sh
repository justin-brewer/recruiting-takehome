post () {
	echo "arg 1: $1"
	echo "arg 2: $2"
	echo "arg 3: $3"
	curl -k -X POST https://localhost:5001/api/robots/closest \
	-H 'Content-Type: application/json' \
	-d '{"loadId":"'$1'","x":"'$2'", "y": "'$3'"}'
	echo ""
}

posti () {
	echo "arg 1: $1"
	echo "arg 2: $2"
	echo "arg 3: $3"
	curl -k -X POST http://localhost:5000/api/robots/closest \
	-H 'Content-Type: application/json' \
	-d '{"loadId":"'$1'","x":"'$2'", "y": "'$3'"}'
	echo ""
}

postz () {
	echo "arg 1: $1"
	echo "arg 2: $2"
	echo "arg 3: $3"
	curl -k -X POST https://0.0.0.0:5001/api/robots/closest \
	-H 'Content-Type: application/json' \
	-d '{"loadId":"'$1'","x":"'$2'", "y": "'$3'"}'
	echo ""
}

postiz () {
	echo "arg 1: $1"
	echo "arg 2: $2"
	echo "arg 3: $3"
	curl -k -X POST http://0.0.0.0:5000/api/robots/closest \
	-H 'Content-Type: application/json' \
	-d '{"loadId":"'$1'","x":"'$2'", "y": "'$3'"}'
	echo ""
}

posth () {
	echo "arg 1: $1"
	echo "arg 2: $2"
	echo "arg 3: $3"
	curl -k -X POST http://0.0.0.0:5000/api/robots/closest \
	-H 'Content-Type: application/json' \
	-d '{"loadId":"1","x":"22", "y": "33"}'
	echo ""
}
