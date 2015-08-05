
if(canMove) {
    
    var moveHoriz = false;
    var moveVert = false;
    
    var horizAngle = 0;
    var vertAngle = 0;
    
    if(keyboard_check(KEY_UP) ^^ keyboard_check(KEY_DOWN)) {
        moveVert = true;
        if(keyboard_check(KEY_UP)) {
            vertAngle = ANGLE_UP;
        }
        else {
            vertAngle = ANGLE_DOWN ;
        }
    }
    
    if(keyboard_check(KEY_RIGHT) ^^ keyboard_check(KEY_LEFT)) {
        moveHoriz = true;
        if(keyboard_check(KEY_RIGHT)) {
            horizAngle = ANGLE_RIGHT;
        }
        else {
            horizAngle = ANGLE_LEFT;
        }
    }
    
    if(moveHoriz && moveVert) {
        if(vertAngle == ANGLE_DOWN && horizAngle == ANGLE_RIGHT) {
            horizAngle += 360;
        }
        motion_set((horizAngle + vertAngle)/2, moveSpeed);
    }
    else if(moveHoriz) {
        motion_set(horizAngle, moveSpeed);
    }
    else if(moveVert) {
        motion_set(vertAngle, moveSpeed);
    }
    else {
        motion_set(direction, 0);
    }
    
}

if(canAttack) {
    if(keyboard_check(KEY_ATTACK)) {
        instance_create(x + 10, y, obj_slash);
    }
}

if(canDash) {
    if(keyboard_check(KEY_DASH)) {
        canMove = false;
        canDash = false;   
        speed = DASH_SPEED;
        alarm[0] = 10;
    }
}
    

